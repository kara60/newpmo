import apiClient from '../api/apiClient.js';

export async function loadTasks() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Ýþler</h2>
        <div id="tasks-list"></div>`;

    const res = await apiClient.get('/tasks');
    if (res.success) {
        document.getElementById('tasks-list').innerHTML = res.data.map(task =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${task.title}</div>
                <div class="text-sm text-gray-500">${task.project?.name || ''}</div>
                <div class="text-xs">${task.taskStatus?.name || ''}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('tasks-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}