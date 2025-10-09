import apiClient from '../api/apiClient.js';

export async function loadUsers() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Personel</h2>
        <div id="users-list"></div>`;

    const res = await apiClient.get('/users');
    if (res.success) {
        document.getElementById('users-list').innerHTML = res.data.map(user =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${user.fullName}</div>
                <div class="text-sm text-gray-500">${user.email}</div>
                <div class="text-xs">${user.position?.name || ''}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('users-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}
