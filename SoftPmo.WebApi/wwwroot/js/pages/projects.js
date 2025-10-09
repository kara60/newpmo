import apiClient from '../api/apiClient.js';

export async function loadProjects() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Projeler</h2>
        <div id="projects-list"></div>`;

    const res = await apiClient.get('/projects');
    if (res.success) {
        document.getElementById('projects-list').innerHTML = res.data.map(proj =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${proj.name}</div>
                <div class="text-sm text-gray-500">${proj.customer?.name || ''}</div>
                <div class="text-xs">${proj.projectStatus?.name || ''}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('projects-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}
