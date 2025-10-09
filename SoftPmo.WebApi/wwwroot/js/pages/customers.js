import apiClient from '../api/apiClient.js';

export async function loadCustomers() {
    const content = document.getElementById('content');
    content.innerHTML = `<h2 class="text-xl font-bold mb-4">Müþteriler</h2>
        <div id="customers-list"></div>`;

    const res = await apiClient.get('/customers');
    if (res.success) {
        document.getElementById('customers-list').innerHTML = res.data.map(cust =>
            `<div class="card p-4 mb-2">
                <div class="font-bold">${cust.name}</div>
                <div class="text-sm text-gray-500">${cust.email}</div>
                <div class="text-xs">${cust.taxNumber}</div>
            </div>`
        ).join('');
    } else {
        document.getElementById('customers-list').innerHTML = `<div class="text-red-500">${res.message}</div>`;
    }
}
