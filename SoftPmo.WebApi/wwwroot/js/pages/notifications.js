import apiClient from '../api/apiClient.js';

export async function loadNotifications() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Bildirimler</h2>
        <div id="notifications-list"></div>`;

    const res = await apiClient.get('/notifications');
    if (res.success) {
        document.getElementById('notifications-list').innerHTML = res.data.map(notif =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${notif.title}</div>
                <div class="text-sm text-gray-500">${notif.message}</div>
                <div class="text-xs">${notif.isRead ? 'Okundu' : 'Yeni'}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('notifications-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}
