import locationApi from '../api/locationApi.js';
import { showToast } from '../utils/toast.js';
import { formatDate, getStatusBadge, showLoading } from '../utils/helpers.js';
import { Modal, showConfirmModal } from '../components/Modal.js';

let currentLocations = [];

export async function loadLocations() {
    const content = document.getElementById('content');

    content.innerHTML = `
        <div class="animate-fade-in">
            
            <!-- Header -->
            <div class="flex flex-col md:flex-row md:items-center md:justify-between mb-6 space-y-4 md:space-y-0">
                <div>
                    <h1 class="text-3xl font-bold text-gray-900">Lokasyonlar</h1>
                    <p class="text-gray-600 mt-1">Ofis ve müşteri lokasyonlarını yönetin</p>
                </div>
                <button onclick="window.openLocationModal(null, 'create')" 
                    class="inline-flex items-center px-6 py-3 bg-gradient-to-r from-blue-600 to-blue-700 text-white rounded-xl hover:from-blue-700 hover:to-blue-800 transition shadow-lg hover:shadow-xl font-medium">
                    <i class="fas fa-plus mr-2"></i>
                    Yeni Lokasyon
                </button>
            </div>

            <!-- Filters -->
            <div class="card p-6 mb-6">
                <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
                    <div class="md:col-span-2 relative">
                        <input type="text" id="search-input" placeholder="Lokasyon ara..." 
                            class="w-full pl-11 pr-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                        <i class="fas fa-search absolute left-4 top-1/2 -translate-y-1/2 text-gray-400"></i>
                    </div>
                    <select id="filter-status" class="px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500">
                        <option value="all">Tüm Durumlar</option>
                        <option value="true">Aktif</option>
                        <option value="false">Pasif</option>
                    </select>
                </div>
            </div>

            <!-- Table -->
            <div class="card overflow-hidden">
                <div id="locations-table-container"></div>
            </div>

        </div>
    `;

    await fetchAndRenderLocations();
    setupEventListeners();
}

async function fetchAndRenderLocations() {
    const container = document.getElementById('locations-table-container');
    showLoading('locations-table-container');

    const result = await locationApi.getAll();

    if (result.success) {
        currentLocations = result.data || [];
        renderTable(currentLocations);
    } else {
        container.innerHTML = `
            <div class="p-8 text-center text-red-600">
                <i class="fas fa-exclamation-circle text-4xl mb-3"></i>
                <p>${result.message}</p>
            </div>
        `;
        showToast(result.message, 'error');
    }
}

function renderTable(locations) {
    const container = document.getElementById('locations-table-container');

    if (!locations || locations.length === 0) {
        container.innerHTML = `
            <div class="p-16 text-center">
                <div class="w-20 h-20 bg-gradient-to-br from-gray-100 to-gray-200 rounded-2xl flex items-center justify-center mx-auto mb-4">
                    <i class="fas fa-map-marker-alt text-4xl text-gray-400"></i>
                </div>
                <h3 class="text-xl font-bold text-gray-900 mb-2">Henüz lokasyon bulunmuyor</h3>
                <p class="text-gray-600 mb-6">Hemen yeni bir lokasyon ekleyin</p>
                <button onclick="window.openLocationModal(null, 'create')" 
                    class="inline-flex items-center px-6 py-3 bg-gradient-to-r from-blue-600 to-blue-700 text-white rounded-xl hover:shadow-lg transition">
                    <i class="fas fa-plus mr-2"></i>Yeni Lokasyon
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
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Lokasyon Adı</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Adres</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Telefon</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Durum</th>
                    <th class="px-6 py-4 text-left text-xs font-bold text-gray-600 uppercase tracking-wider">Oluşturulma</th>
                    <th class="px-6 py-4 text-right text-xs font-bold text-gray-600 uppercase tracking-wider">İşlemler</th>
                </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-100">
                ${locations.map(location => `
                    <tr class="table-row" onclick="window.openLocationModal('${location.id}', 'view')">
                        <td class="px-6 py-4 whitespace-nowrap">
                            <span class="text-sm font-mono font-semibold text-gray-900">${location.code || '-'}</span>
                        </td>
                        <td class="px-6 py-4">
                            <div class="flex items-center">
                                <div class="w-10 h-10 bg-gradient-to-br from-blue-500 to-purple-600 rounded-xl flex items-center justify-center text-white mr-3">
                                    <i class="fas fa-map-marker-alt"></i>
                                </div>
                                <div>
                                    <div class="text-sm font-semibold text-gray-900">${location.name}</div>
                                    <div class="text-xs text-gray-500">${location.description || 'Açıklama yok'}</div>
                                </div>
                            </div>
                        </td>
                        <td class="px-6 py-4 text-sm text-gray-600 max-w-xs truncate">
                            ${location.address || '-'}
                        </td>
                        <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-600">
                            ${location.phone ? `<i class="fas fa-phone text-xs mr-2"></i>${location.phone}` : '-'}
                        </td>
                        <td class="px-6 py-4 whitespace-nowrap">
                            ${getStatusBadge(location.isActive)}
                        </td>
                        <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-600">
                            ${formatDate(location.createdDate)}
                        </td>
                        <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium space-x-2">
                            <button onclick="event.stopPropagation(); window.openLocationModal('${location.id}', 'edit')" 
                                class="text-blue-600 hover:text-blue-800 transition p-2 hover:bg-blue-50 rounded-lg">
                                <i class="fas fa-edit"></i>
                            </button>
                            <button onclick="event.stopPropagation(); window.deleteLocation('${location.id}')" 
                                class="text-red-600 hover:text-red-800 transition p-2 hover:bg-red-50 rounded-lg">
                                <i class="fas fa-trash"></i>
                            </button>
                        </td>
                    </tr>
                `).join('')}
            </tbody>
        </table>
    `;

    container.innerHTML = tableHTML;
}

function setupEventListeners() {
    const searchInput = document.getElementById('search-input');
    if (searchInput) {
        searchInput.addEventListener('input', filterLocations);
    }

    const filterStatus = document.getElementById('filter-status');
    if (filterStatus) {
        filterStatus.addEventListener('change', filterLocations);
    }
}

function filterLocations() {
    const searchTerm = document.getElementById('search-input')?.value.toLowerCase() || '';
    const statusFilter = document.getElementById('filter-status')?.value || 'all';

    let filtered = currentLocations.filter(location => {
        const matchesSearch = !searchTerm ||
            location.name?.toLowerCase().includes(searchTerm) ||
            location.code?.toLowerCase().includes(searchTerm) ||
            location.address?.toLowerCase().includes(searchTerm);

        const matchesStatus = statusFilter === 'all' ||
            location.isActive.toString() === statusFilter;

        return matchesSearch && matchesStatus;
    });

    renderTable(filtered);
}

window.openLocationModal = function (locationId = null, mode = 'view') {
    const location = locationId ? currentLocations.find(l => l.id === locationId) : null;

    const formHTML = `
        <form id="location-form" class="space-y-6">
            <input type="hidden" id="location-id" value="${location?.id || ''}">
            
            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                    <label class="block text-sm font-semibold text-gray-700 mb-2">
                        Lokasyon Adı <span class="text-red-500">*</span>
                    </label>
                    <input type="text" id="location-name" required
                        value="${location?.name || ''}"
                        class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500"
                        placeholder="Örn: Merkez Ofis">
                </div>

                <div>
                    <label class="block text-sm font-semibold text-gray-700 mb-2">Telefon</label>
                    <input type="text" id="location-phone"
                        value="${location?.phone || ''}"
                        class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500"
                        placeholder="0212 xxx xx xx">
                </div>
            </div>

            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">Adres</label>
                <textarea id="location-address" rows="3"
                    class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500"
                    placeholder="Tam adres giriniz">${location?.address || ''}</textarea>
            </div>

            <div>
                <label class="block text-sm font-semibold text-gray-700 mb-2">Açıklama</label>
                <textarea id="location-description" rows="2"
                    class="w-full px-4 py-3 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500/20 focus:border-primary-500"
                    placeholder="Opsiyonel açıklama">${location?.description || ''}</textarea>
            </div>

            <div class="flex items-center p-4 bg-gray-50 rounded-xl">
                <input type="checkbox" id="location-active" ${location?.isActive !== false ? 'checked' : ''}
                    class="w-5 h-5 text-primary-600 border-gray-300 rounded focus:ring-primary-500">
                <label for="location-active" class="ml-3 text-sm font-medium text-gray-700">Aktif durumda</label>
            </div>
        </form>
    `;

    const modal = new Modal(
        mode === 'create' ? 'Yeni Lokasyon' : location?.name || 'Lokasyon',
        formHTML,
        {
            size: 'lg',
            mode: mode,
            data: location,
            onEdit: () => {
                // Edit mode'a geçince form enable olacak
            },
            onSave: async () => {
                return await saveLocation();
            }
        }
    );

    modal.open();
};

async function saveLocation() {
    const id = document.getElementById('location-id')?.value;
    const name = document.getElementById('location-name')?.value;
    const phone = document.getElementById('location-phone')?.value;
    const address = document.getElementById('location-address')?.value;
    const description = document.getElementById('location-description')?.value;
    const isActive = document.getElementById('location-active')?.checked;

    if (!name) {
        showToast('Lokasyon adı zorunludur', 'error');
        return false;
    }

    const data = {
        name: name.trim(),
        phone: phone?.trim() || '',
        address: address?.trim() || '',
        description: description?.trim() || '',
        isActive: isActive
    };

    let result;
    if (id) {
        data.id = id;
        result = await locationApi.update(data);
    } else {
        result = await locationApi.create(data);
    }

    if (result.success) {
        showToast(id ? 'Lokasyon güncellendi' : 'Lokasyon eklendi', 'success');
        await fetchAndRenderLocations();
        return true;
    } else {
        showToast(result.message, 'error');
        return false;
    }
}

window.deleteLocation = function (id) {
    const location = currentLocations.find(l => l.id === id);
    if (!location) return;

    showConfirmModal(
        'Lokasyonu Sil',
        `"${location.name}" lokasyonunu silmek istediğinize emin misiniz? Bu işlem geri alınamaz.`,
        async () => {
            const result = await locationApi.delete(id);
            if (result.success) {
                showToast('Lokasyon başarıyla silindi', 'success');
                await fetchAndRenderLocations();
            } else {
                showToast(result.message, 'error');
            }
        }
    );
};