import apiClient from '../api/apiClient.js';

export async function loadPriorities() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Öncelikler</h2>
        <div id="priorities-list"></div>`;

    const res = await apiClient.get('/priorities');
    if (res.success) {
        document.getElementById('priorities-list').innerHTML = res.data.map(prio =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${prio.name}</div>
                <div class="text-xs">${prio.colorCode}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('priorities-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}
