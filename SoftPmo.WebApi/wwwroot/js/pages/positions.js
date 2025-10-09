import positionApi from '../api/positionApi.js';
import positionLevelApi from '../api/positionLevelApi.js';
import departmentApi from '../api/departmentApi.js';
import { showToast } from '../utils/toast.js';
import { formatDate, getStatusBadge, showLoading } from '../utils/helpers.js';
import { Modal, showConfirmModal } from '../components/Modal.js';

let currentPositions = [];
let departments = [];
let levels = [];

export async function loadPositions() {
    const content = document.getElementById('content');

    content.innerHTML = `
        <div class="animate-fade-in">
            <div class="flex items-center justify-between mb-6">
                <div>
                    <h1 class="text-2xl font-bold text-gray-900">Pozisyonlar</h1>
                    <p class="text-sm text-gray-600 mt-1">Çalışan pozisyonlarını ve rollerini yönetin</p>
                </div>
                <button onclick="window.openPositionModal()" class="bg-primary text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition">
                    <i class="fas fa-plus mr-2"></i>Yeni Pozisyon
                </button>
            </div>

            <div class="bg-white rounded-lg border border-gray-200 p-4 mb-6">
                <div class="flex flex-col md:flex-row md:items-center space-y-3 md:space-y-0 md:space-x-4">
                    <div class="flex-1 relative">
                        <input type="text" id="search-input" placeholder="Pozisyon ara..." 
                            class="w-full pl-10 pr-4 py-2 border border-gray-300 rounded-lg">
                        <i class="fas fa-search absolute left-3 top-1/2 -translate-y-1/2 text-gray-400"></i>
                    </div>
                    <select id="filter-department" class="px-4 py-2 border border-gray-300 rounded-lg">
                        <option value="all">Tüm Departmanlar</option>
                    </select>
                    <select id="filter-status" class="px-4 py-2 border border-gray-300 rounded-lg">
                        <option value="all">Tüm Durumlar</option>
                        <option value="true">Aktif</option>
                        <option value="false">Pasif</option>
                    </select>
                </div>
            </div>

            <div class="bg-white rounded-lg border border-gray-200">
                <div id="positions-table-container"></div>
            </div>
        </div>
    `;

    await fetchAndRenderPositions();
    setupEventListeners();
}

async function fetchAndRenderPositions() {
    const container = document.getElementById('positions-table-container');
    showLoading('positions-table-container');

    const [posResult, deptResult, levelResult] = await Promise.all([
        positionApi.getAll(),
        departmentApi.getAll(),
        positionLevelApi.getAll()
    ]);

    if (posResult.success) {
        currentPositions = posResult.data || [];
        departments = deptResult.data || [];
        levels = levelResult.data || [];

        // Populate department filter
        populateDepartmentFilter();

        renderTable(currentPositions);
    } else {
        container.innerHTML = `<div class="p-8 text-center text-red-600">${posResult.message}</div>`;
        showToast(posResult.message, 'error');
    }
}

function populateDepartmentFilter() {
    const filterDept = document.getElementById('filter-department');
    if (!filterDept) return;

    const currentValue = filterDept.value;
    filterDept.innerHTML = '<option value="all">Tüm Departmanlar</option>';

    departments.forEach(dept => {
        const option = document.createElement('option');
        option.value = dept.id;
        option.textContent = dept.name;
        if (dept.id === currentValue) option.selected = true;
        filterDept.appendChild(option);
    });
}

function renderTable(positions) {
    const container = document.getElementById('positions-table-container');

    if (!positions || positions.length === 0) {
        container.innerHTML = `
            <div class="p-16 text-center">
                <div class="w-20 h-20 bg-gradient-to-br from-gray-100 to-gray-200 rounded-2xl flex items-center justify-center mx-auto mb-4">
                    <i class="fas fa-user-tag text-4xl text-gray-400"></i>
                </div>
                <h3 class="text-xl font-bold text-gray-900 mb-2">Henüz pozisyon bulunmuyor</h3>
                <p class="text-gray-600 mb-6">İlk pozisyonu ekleyerek başlayın</p>
                <button onclick="window.openPositionModal(null, 'create')" 
                    class="inline-flex items-center px-6 py-3 bg-gradient-to-r from-blue-600 to-blue-700 text-white rounded-xl hover:shadow-lg transition">
                    <i class="fas fa-plus mr-2"></i>Yeni Pozisyon
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
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Pozisyon</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Departman</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Seviye</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Çarpan</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Durum</th>
                    <th class="px-6 py-4 text-right text-xs font-bold text-gray-600 uppercase tracking-wider">İşlemler</th>
                </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-100">
                ${positions.map(pos => {
        const department = departments.find(d => d.id === pos.departmentId);
        const level = levels.find(l => l.id === pos.positionLevelId);

        return `
                        <tr class="table-row" onclick="window.openPositionModal('${pos.id}', 'view')">
                            <td class="px-6 py-4 text-sm font-mono font-semibold">${pos.code || '-'}</td>
                            <td class="px-6 py-4">
                                <div class="flex items-center">
                                    <div class="w-10 h-10 bg-gradient-to-br from-green-500 to-teal-600 rounded-xl flex items-center justify-center text-white mr-3">
                                        <i class="fas fa-user-tie"></i>
                                    </div>
                                    <div>
                                        <div class="text-sm font-semibold text-gray-900">${pos.name}</div>
                                        <div class="text-xs text-gray-500">${pos.description || 'Açıklama yok'}</div>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4 text-sm text-gray-600">${department?.name || '-'}</td>
                            <td class="px-6 py-4">
                                <span class="inline-flex items-center px-3 py-1 rounded-full text-xs font-bold ${getLevelColor(level?.name)}">
                                    ${level?.name || '-'}
                                </span>
                            </td>
                            <td class="px-6 py-4">
                                <span class="text-sm font-bold text-gray-900">${pos.billingMultiplier}x</span>
                            </td>
                            <td class="px-6 py-4">${getStatusBadge(pos.isActive)}</td>
                            <td class="px-6 py-4 text-right space-x-2">
                                <button onclick="event.stopPropagation(); window.openPositionModal('${pos.id}', 'edit')" 
                                    class="text-blue-600 hover:text-blue-800 transition p-2 hover:bg-blue-50 rounded-lg">
                                    <i class="fas fa-edit"></i>
                                </button>
                                <button onclick="event.stopPropagation(); window.deletePosition('${pos.id}')" 
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

function getLevelColor(levelName) {
    const colors = {
        'Junior': 'bg-blue-100 text-blue-800',
        'Mid': 'bg-green-100 text-green-800',
        'Senior': 'bg-purple-100 text-purple-800',
        'Lead': 'bg-red-100 text-red-800'
    };
    return colors[levelName] || 'bg-gray-100 text-gray-800';
}

function setupEventListeners() {
    const searchInput = document.getElementById('search-input');
    if (searchInput) {
        searchInput.addEventListener('input', filterPositions);
    }

    const filterDept = document.getElementById('filter-department');
    if (filterDept) {
        filterDept.addEventListener('change', filterPositions);
    }

    const filterStatus = document.getElementById('filter-status');
    if (filterStatus) {
        filterStatus.addEventListener('change', filterPositions);
    }
}

function filterPositions() {
    const searchTerm = document.getElementById('search-input')?.value.toLowerCase() || '';
    const deptFilter = document.getElementById('filter-department')?.value || 'all';
    const statusFilter = document.getElementById('filter-status')?.value || 'all';

    let filtered = currentPositions.filter(pos => {
        const matchesSearch = !searchTerm ||
            pos.name?.toLowerCase().includes(searchTerm) ||
            pos.code?.toLowerCase().includes(searchTerm);

        const matchesDept = deptFilter === 'all' || pos.departmentId === deptFilter;

        const matchesStatus = statusFilter === 'all' ||
            pos.isActive.toString() === statusFilter;

        return matchesSearch && matchesDept && matchesStatus;
    });

    renderTable(filtered);
}

window.openPositionModal = function (positionId = null, mode = 'view') {
    const position = positionId ? currentPositions.find(p => p.id === positionId) : null;

    const formHTML = `
        <form id="position-form" class="space-y-6">
            <input type="hidden" id="position-id" value="${position?.id || ''}">
            
            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                    <label class="block text-sm font-semibold text-gray-700 mb-2">
                        Pozisyon Adı <span class="text-red-500">*</span>
                    </label>
                    <input type="text" id="position-name" required value="${position?.name || ''}"
                        class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500"
                        placeholder="Örn: Yazılım Geliştirici">
                </div>

                <div>
                    <label class="block text-sm font-semibold text-gray-700 mb-2">
                        Departman <span class="text-red-500">*</span>
                    </label>
                    <select id="position-department" required
                        class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                        <option value="">-- Departman Seçin --</option>
                        ${departments.map(d => `
                            <option value="${d.id}" ${position?.departmentId === d.id ? 'selected' : ''}>
                                ${d.name}
                            </option>
                        `).join('')}
                    </select>
                </div>
            </div>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                    <label class="block text-sm font-semibold text-gray-700 mb-2">
                        Seviye <span class="text-red-500">*</span>
                    </label>
                    <select id="position-level" required
                        class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                        <option value="">-- Seviye Seçin --</option>
                        ${levels.map(l => `
                            <option value="${l.id}" ${position?.positionLevelId === l.id ? 'selected' : ''}>
                                ${l.name}
                            </option>
                        `).join('')}
                    </select>
                </div>

                <div>
                    <label class="block text-sm font-semibold text-gray-700 mb-2">
                        Faturalama Çarpanı <span class="text-red-500">*</span>
                    </label>
                    <input type="number" id="position-multiplier" required step="0.1" min="0.1" max="10"
                        value="${position?.billingMultiplier || 1.0}"
                        class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                    <p class="text-xs text-gray-500 mt-1">
                        <i class="fas fa-info-circle mr-1"></i>Müşteri faturalamasında kullanılır
                    </p>
                </div>
            </div>

            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">Açıklama</label>
                <textarea id="position-description" rows="3"
                    class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500"
                    placeholder="Pozisyon açıklaması...">${position?.description || ''}</textarea>
            </div>

            <div class="flex items-center p-4 bg-gray-50 rounded-xl">
                <input type="checkbox" id="position-active" ${position?.isActive !== false ? 'checked' : ''}
                    class="w-5 h-5 text-primary-600 border-gray-300 rounded">
                <label for="position-active" class="ml-3 text-sm font-medium text-gray-700">Aktif durumda</label>
            </div>
        </form>
    `;

    const modal = new Modal(
        mode === 'create' ? 'Yeni Pozisyon' : position?.name || 'Pozisyon',
        formHTML,
        {
            size: 'lg',
            mode: mode,
            data: position,
            onSave: async () => {
                return await savePosition();
            }
        }
    );

    modal.open();
};

async function savePosition() {
    const id = document.getElementById('position-id')?.value;
    const name = document.getElementById('position-name')?.value;
    const departmentId = document.getElementById('position-department')?.value;
    const levelId = document.getElementById('position-level')?.value;
    const multiplier = document.getElementById('position-multiplier')?.value;
    const description = document.getElementById('position-description')?.value;
    const isActive = document.getElementById('position-active')?.checked;

    if (!name) {
        showToast('Pozisyon adı gerekli', 'error');
        return false;
    }

    if (!departmentId) {
        showToast('Departman seçmelisiniz', 'error');
        return false;
    }

    if (!levelId) {
        showToast('Seviye seçmelisiniz', 'error');
        return false;
    }

    const data = {
        name: name.trim(),
        departmentId: departmentId,
        positionLevelId: levelId,
        billingMultiplier: parseFloat(multiplier) || 1.0,
        description: description?.trim() || '',
        isActive: isActive
    };

    let result;
    if (id) {
        data.id = id;
        result = await positionApi.update(data);
    } else {
        result = await positionApi.create(data);
    }

    if (result.success) {
        showToast(id ? 'Pozisyon güncellendi' : 'Pozisyon eklendi', 'success');
        await fetchAndRenderPositions();
        return true;
    } else {
        showToast(result.message, 'error');
        return false;
    }
}

window.editPosition = function (id) {
    window.openPositionModal(id);
};

window.deletePosition = function (id) {
    const position = currentPositions.find(p => p.id === id);
    if (!position) return;

    showConfirmModal(
        'Pozisyonu Sil',
        `"${position.name}" pozisyonunu silmek istediğinize emin misiniz?`,
        async () => {
            const result = await positionApi.delete(id);
            if (result.success) {
                showToast('Pozisyon silindi', 'success');
                await fetchAndRenderPositions();
            } else {
                showToast(result.message, 'error');
            }
        }
    );
};