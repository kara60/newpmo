import departmentApi from '../api/departmentApi.js';
import locationApi from '../api/locationApi.js';
import { showToast } from '../utils/toast.js';
import { formatDate, getStatusBadge, showLoading } from '../utils/helpers.js';
import { Modal, showConfirmModal } from '../components/Modal.js';

let currentDepartments = [];
let locations = [];
let allDepartments = [];

export async function loadDepartments() {
    const content = document.getElementById('content');

    content.innerHTML = `
        <div class="animate-fade-in">
            <div class="flex items-center justify-between mb-6">
                <div>
                    <h1 class="text-2xl font-bold text-gray-900">Departmanlar</h1>
                    <p class="text-sm text-gray-600 mt-1">Organizasyon yapısını yönetin</p>
                </div>
                <button onclick="window.openDepartmentModal()" class="bg-primary text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition">
                    <i class="fas fa-plus mr-2"></i>Yeni Departman
                </button>
            </div>

            <div class="bg-white rounded-lg border border-gray-200 p-4 mb-6">
                <div class="flex items-center space-x-4">
                    <div class="flex-1 relative">
                        <input type="text" id="search-input" placeholder="Departman ara..." 
                            class="w-full pl-10 pr-4 py-2 border border-gray-300 rounded-lg">
                        <i class="fas fa-search absolute left-3 top-1/2 -translate-y-1/2 text-gray-400"></i>
                    </div>
                    <select id="filter-status" class="px-4 py-2 border border-gray-300 rounded-lg">
                        <option value="all">Tüm Durumlar</option>
                        <option value="true">Aktif</option>
                        <option value="false">Pasif</option>
                    </select>
                </div>
            </div>

            <div class="bg-white rounded-lg border border-gray-200">
                <div id="departments-table-container"></div>
            </div>
        </div>
    `;

    await fetchAndRenderDepartments();
    setupEventListeners();
}

async function fetchAndRenderDepartments() {
    const container = document.getElementById('departments-table-container');
    showLoading('departments-table-container');

    const [deptResult, locResult] = await Promise.all([
        departmentApi.getAll(),
        locationApi.getAll()
    ]);

    if (deptResult.success) {
        currentDepartments = deptResult.data || [];
        allDepartments = deptResult.data || [];
        locations = locResult.data || [];
        renderTable(currentDepartments);
    } else {
        container.innerHTML = `<div class="p-8 text-center text-red-600">${deptResult.message}</div>`;
        showToast(deptResult.message, 'error');
    }
}

function renderTable(departments) {
    const container = document.getElementById('departments-table-container');

    if (!departments || departments.length === 0) {
        container.innerHTML = `
            <div class="p-16 text-center">
                <div class="w-20 h-20 bg-gradient-to-br from-gray-100 to-gray-200 rounded-2xl flex items-center justify-center mx-auto mb-4">
                    <i class="fas fa-sitemap text-4xl text-gray-400"></i>
                </div>
                <h3 class="text-xl font-bold text-gray-900 mb-2">Henüz departman bulunmuyor</h3>
                <p class="text-gray-600 mb-6">Organizasyon yapınızı oluşturmaya başlayın</p>
                <button onclick="window.openDepartmentModal(null, 'create')" 
                    class="inline-flex items-center px-6 py-3 bg-gradient-to-r from-blue-600 to-blue-700 text-white rounded-xl hover:shadow-lg transition">
                    <i class="fas fa-plus mr-2"></i>Yeni Departman
                </button>
            </div>
        `;
        return;
    }

    const tableHTML = `
        <table class="min-w-full divide-y divide-gray-200">
            <thead class="bg-gradient-to-r from-gray-50 to-gray-100">
                <tr>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Kod</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Departman</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Üst Departman</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Lokasyon</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Durum</th>
                    <th class="px-6 py-4 text-right text-xs font-bold text-gray-600 uppercase tracking-wider">İşlemler</th>
                </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-100">
                ${departments.map(dept => {
        const parentDept = allDepartments.find(d => d.id === dept.parentDepartmentId);
        const location = locations.find(l => l.id === dept.locationId);

        return `
                        <tr class="table-row" onclick="window.openDepartmentModal('${dept.id}', 'view')">
                            <td class="px-6 py-4 text-sm font-mono font-semibold">${dept.code || '-'}</td>
                            <td class="px-6 py-4">
                                <div class="flex items-center">
                                    <div class="w-10 h-10 bg-gradient-to-br from-purple-500 to-pink-600 rounded-xl flex items-center justify-center text-white mr-3">
                                        <i class="fas fa-sitemap"></i>
                                    </div>
                                    <div>
                                        <div class="text-sm font-semibold text-gray-900">${dept.name}</div>
                                        <div class="text-xs text-gray-500">${dept.description || 'Açıklama yok'}</div>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4 text-sm text-gray-600">${parentDept?.name || '-'}</td>
                            <td class="px-6 py-4 text-sm text-gray-600">${location?.name || '-'}</td>
                            <td class="px-6 py-4">${getStatusBadge(dept.isActive)}</td>
                            <td class="px-6 py-4 text-right space-x-2">
                                <button onclick="event.stopPropagation(); window.openDepartmentModal('${dept.id}', 'edit')" 
                                    class="text-blue-600 hover:text-blue-800 transition p-2 hover:bg-blue-50 rounded-lg">
                                    <i class="fas fa-edit"></i>
                                </button>
                                <button onclick="event.stopPropagation(); window.deleteDepartment('${dept.id}')" 
                                    class="text-red-600 hover:text-red-800 transition p-2 hover:bg-red-50 rounded-lg">
                                    <i class="fas fa-trash"></i>
                                </button>
                            </td>
                        </tr>
                    `;
    }).join('')}
            </tbody>
        </table>
    `;

    container.innerHTML = tableHTML;
}

function setupEventListeners() {
    const searchInput = document.getElementById('search-input');
    if (searchInput) {
        searchInput.addEventListener('input', filterDepartments);
    }

    const filterStatus = document.getElementById('filter-status');
    if (filterStatus) {
        filterStatus.addEventListener('change', filterDepartments);
    }
}

function filterDepartments() {
    const searchTerm = document.getElementById('search-input')?.value.toLowerCase() || '';
    const statusFilter = document.getElementById('filter-status')?.value || 'all';

    let filtered = allDepartments.filter(dept => {
        const matchesSearch = !searchTerm ||
            dept.name?.toLowerCase().includes(searchTerm) ||
            dept.code?.toLowerCase().includes(searchTerm);

        const matchesStatus = statusFilter === 'all' ||
            dept.isActive.toString() === statusFilter;

        return matchesSearch && matchesStatus;
    });

    renderTable(filtered);
}

window.openDepartmentModal = function (departmentId = null, mode = 'view') {
    const isEdit = !!departmentId;
    const department = isEdit ? currentDepartments.find(d => d.id === departmentId) : null;

    const formHTML = `
        <form id="department-form" class="space-y-6">
            <input type="hidden" id="department-id" value="${department?.id || ''}">
            
            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">
                    Departman Adı <span class="text-red-500">*</span>
                </label>
                <input type="text" id="department-name" required value="${department?.name || ''}"
                    class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
            </div>

            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">Üst Departman</label>
                <select id="department-parent" class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                    <option value="">-- Üst Departman Yok --</option>
                    ${allDepartments.filter(d => d.id !== departmentId).map(d => `
                        <option value="${d.id}" ${department?.parentDepartmentId === d.id ? 'selected' : ''}>
                            ${d.name}
                        </option>
                    `).join('')}
                </select>
            </div>

            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">Lokasyon</label>
                <select id="department-location" class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                    <option value="">-- Lokasyon Seçin --</option>
                    ${locations.map(l => `
                        <option value="${l.id}" ${department?.locationId === l.id ? 'selected' : ''}>
                            ${l.name}
                        </option>
                    `).join('')}
                </select>
            </div>

            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">Açıklama</label>
                <textarea id="department-description" rows="3"
                    class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">${department?.description || ''}</textarea>
            </div>

            <div class="flex items-center p-4 bg-gray-50 rounded-xl">
                <input type="checkbox" id="department-active" ${department?.isActive !== false ? 'checked' : ''}
                    class="w-5 h-5 text-primary-600 border-gray-300 rounded">
                <label for="department-active" class="ml-3 text-sm font-medium text-gray-700">Aktif durumda</label>
            </div>
        </form>
    `;

    const modal = new Modal(
        mode === 'create' ? 'Yeni Departman' : department?.name || 'Departman',
        formHTML,
        {
            size: 'lg',
            mode: mode,
            data: department,
            onSave: async () => {
                return await saveDepartment();
            }
        }
    );

    modal.open();
};

async function saveDepartment() {
    const id = document.getElementById('department-id')?.value;
    const name = document.getElementById('department-name')?.value;
    const parentId = document.getElementById('department-parent')?.value;
    const locationId = document.getElementById('department-location')?.value;
    const description = document.getElementById('department-description')?.value;
    const isActive = document.getElementById('department-active')?.checked;

    if (!name) {
        showToast('Departman adı gerekli', 'error');
        return false;
    }

    const data = {
        name: name.trim(),
        parentDepartmentId: parentId || null,
        locationId: locationId || null,
        managerId: null,
        description: description?.trim() || '',
        isActive: isActive
    };

    let result;
    if (id) {
        data.id = id;
        result = await departmentApi.update(data);
    } else {
        result = await departmentApi.create(data);
    }

    if (result.success) {
        showToast(id ? 'Departman güncellendi' : 'Departman eklendi', 'success');
        await fetchAndRenderDepartments();
        return true;
    } else {
        showToast(result.message, 'error');
        return false;
    }
}

window.editDepartment = function (id) {
    window.openDepartmentModal(id);
};

window.deleteDepartment = function (id) {
    const department = currentDepartments.find(d => d.id === id);
    if (!department) return;

    showConfirmModal(
        'Departmanı Sil',
        `"${department.name}" departmanını silmek istediğinize emin misiniz?`,
        async () => {
            const result = await departmentApi.delete(id);
            if (result.success) {
                showToast('Departman silindi', 'success');
                await fetchAndRenderDepartments();
            } else {
                showToast(result.message, 'error');
            }
        }
    );
};