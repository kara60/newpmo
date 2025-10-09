import apiClient from '../api/apiClient.js';

export async function loadProjectTypes() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Proje Tipleri</h2>
        <div id="project-types-list"></div>`;

    const res = await apiClient.get('/project-types');
    const types = Array.isArray(res.data) ? res.data : [];
    if (types.length > 0) {
        document.getElementById('project-types-list').innerHTML = types.map(type =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${type.name}</div>
                <div class="text-xs">${type.category}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('project-types-list').innerHTML = `<div class="text-red-500">Veri bulunamadý veya format hatasý.</div>`;
    }
}
