import apiClient from '../api/apiClient.js';

export async function loadProjectRoles() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Proje Rolleri</h2>
        <div id="project-roles-list"></div>`;

    const res = await apiClient.get('/project-roles');
    const roles = Array.isArray(res.data) ? res.data : [];
    if (roles.length > 0) {
        document.getElementById('project-roles-list').innerHTML = roles.map(role =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${role.name}</div>
                <div class="text-xs">${role.code}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('project-roles-list').innerHTML = `<div class="text-red-500">Veri bulunamadý veya format hatasý.</div>`;
    }
}