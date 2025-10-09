import apiClient from '../api/apiClient.js';

export async function loadSteps() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Adýmlar</h2>
        <div id="steps-list"></div>`;

    const res = await apiClient.get('/steps');
    if (res.success) {
        document.getElementById('steps-list').innerHTML = res.data.map(step =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${step.name}</div>
                <div class="text-xs">${step.code}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('steps-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}
