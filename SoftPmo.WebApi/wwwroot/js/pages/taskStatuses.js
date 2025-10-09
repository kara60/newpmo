import apiClient from '../api/apiClient.js';

export async function loadTaskStatuses() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">�� Durumlar�</h2>
        <div id="task-statuses-list"></div>`;

    const res = await apiClient.get('/task-statuses');
    const statuses = Array.isArray(res.data) ? res.data : [];
    if (statuses.length > 0) {
        document.getElementById('task-statuses-list').innerHTML = statuses.map(status =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${status.name}</div>
                <div class="text-xs">${status.statusType}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('task-statuses-list').innerHTML = `<div class="text-red-500">Veri bulunamad� veya format hatas�.</div>`;
    }
}
