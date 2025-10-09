// ====================================
// DASHBOARD PAGE - PERSONEL & YÖNETİCİ
// ====================================

import { showToast } from '../utils/toast.js';

// Simulated user role (gerçekte API'den gelecek)
const currentUser = {
    role: 'manager', // 'employee' veya 'manager'
    name: 'Mehmet Yılmaz',
    position: 'Senior Developer'
};

export function loadDashboard() {
    const content = document.getElementById('content');

    if (currentUser.role === 'manager') {
        loadManagerDashboard(content);
    } else {
        loadEmployeeDashboard(content);
    }
}

// ====================================
// PERSONEL DASHBOARD
// ====================================
function loadEmployeeDashboard(content) {
    content.innerHTML = `
        <div class="animate-fade-in space-y-6">
            
            <!-- Welcome Header -->
            <div class="card p-6 bg-gradient-to-r from-blue-600 to-purple-600 text-white">
                <div class="flex items-center justify-between">
                    <div>
                        <h1 class="text-3xl font-bold mb-2">👋 Hoş Geldin, ${currentUser.name}!</h1>
                        <p class="text-blue-100">Bugün harika işler çıkaracaksın!</p>
                    </div>
                    <div class="text-right">
                        <div class="text-sm text-blue-100">Bugün</div>
                        <div class="text-2xl font-bold">${new Date().toLocaleDateString('tr-TR', { day: 'numeric', month: 'long' })}</div>
                        <div class="text-sm text-blue-100">${new Date().toLocaleDateString('tr-TR', { weekday: 'long' })}</div>
                    </div>
                </div>
            </div>

            <!-- Quick Stats -->
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
                
                <!-- Bugün Çalışma -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-blue-500 to-blue-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-clock text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-blue-600 bg-blue-50 px-2 py-1 rounded-full">BUGÜN</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Bugün Çalışma</h3>
                    <p class="text-3xl font-bold text-gray-900">0h 0m</p>
                    <div class="mt-3 flex items-center text-xs">
                        <div class="flex-1 bg-gray-200 rounded-full h-2 mr-2">
                            <div class="bg-gradient-to-r from-blue-500 to-blue-600 h-2 rounded-full" style="width: 0%"></div>
                        </div>
                        <span class="text-gray-500 font-medium">0/8h</span>
                    </div>
                </div>

                <!-- Aktif İşler -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-green-500 to-green-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-tasks text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-green-600 bg-green-50 px-2 py-1 rounded-full">AKTİF</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Aktif İşlerim</h3>
                    <p class="text-3xl font-bold text-gray-900">0</p>
                    <p class="text-xs text-green-600 mt-2">
                        <i class="fas fa-arrow-up mr-1"></i>Devam eden
                    </p>
                </div>

                <!-- Bu Hafta -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-purple-500 to-purple-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-calendar-week text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-purple-600 bg-purple-50 px-2 py-1 rounded-full">HAFTA</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Bu Hafta</h3>
                    <p class="text-3xl font-bold text-gray-900">0h</p>
                    <p class="text-xs text-gray-500 mt-2">Toplam çalışma</p>
                </div>

                <!-- Tamamlanan -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-orange-500 to-orange-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-check-circle text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-orange-600 bg-orange-50 px-2 py-1 rounded-full">BU AY</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Tamamlanan</h3>
                    <p class="text-3xl font-bold text-gray-900">0</p>
                    <p class="text-xs text-orange-600 mt-2">
                        <i class="fas fa-trophy mr-1"></i>İş başarısı
                    </p>
                </div>

            </div>

            <!-- Main Content Grid -->
            <div class="grid grid-cols-1 lg:grid-cols-3 gap-6">
                
                <!-- Left Column - 2/3 -->
                <div class="lg:col-span-2 space-y-6">
                    
                    <!-- Öncelikli İşlerim -->
                    <div class="card">
                        <div class="p-6 border-b border-gray-100">
                            <div class="flex items-center justify-between">
                                <div>
                                    <h2 class="text-xl font-bold text-gray-900">🎯 Öncelikli İşlerim</h2>
                                    <p class="text-sm text-gray-600 mt-1">Hemen yapılması gerekenler</p>
                                </div>
                                <a href="#tasks" class="text-sm font-semibold text-blue-600 hover:text-blue-700">
                                    Tümünü Gör <i class="fas fa-arrow-right ml-1"></i>
                                </a>
                            </div>
                        </div>
                        <div class="p-6">
                            ${generatePriorityTasks()}
                        </div>
                    </div>

                    <!-- Deadline Yaklaşanlar -->
                    <div class="card">
                        <div class="p-6 border-b border-gray-100">
                            <div class="flex items-center justify-between">
                                <div>
                                    <h2 class="text-xl font-bold text-gray-900">⚠️ Deadline Yaklaşanlar</h2>
                                    <p class="text-sm text-gray-600 mt-1">Dikkat edilmesi gerekenler</p>
                                </div>
                            </div>
                        </div>
                        <div class="p-6">
                            ${generateUpcomingDeadlines()}
                        </div>
                    </div>

                    <!-- Son Faaliyetler -->
                    <div class="card">
                        <div class="p-6 border-b border-gray-100">
                            <h2 class="text-xl font-bold text-gray-900">📊 Son Faaliyetlerim</h2>
                        </div>
                        <div class="divide-y divide-gray-100">
                            ${generateRecentActivities()}
                        </div>
                    </div>

                </div>

                <!-- Right Column - 1/3 -->
                <div class="space-y-6">
                    
                    <!-- Hızlı İşlemler -->
                    <div class="card p-6">
                        <h3 class="text-lg font-bold text-gray-900 mb-4">⚡ Hızlı İşlemler</h3>
                        <div class="space-y-3">
                            <button onclick="window.location.hash='activities'" class="w-full flex items-center space-x-3 p-4 bg-gradient-to-r from-blue-50 to-purple-50 rounded-xl hover:shadow-md transition">
                                <div class="w-10 h-10 bg-gradient-to-br from-blue-500 to-blue-600 rounded-lg flex items-center justify-center flex-shrink-0">
                                    <i class="fas fa-clock text-white"></i>
                                </div>
                                <div class="text-left">
                                    <p class="font-semibold text-sm text-gray-900">Faaliyet Gir</p>
                                    <p class="text-xs text-gray-600">Günlük çalışma kaydet</p>
                                </div>
                            </button>
                            <button onclick="window.location.hash='tasks'" class="w-full flex items-center space-x-3 p-4 bg-gradient-to-r from-green-50 to-teal-50 rounded-xl hover:shadow-md transition">
                                <div class="w-10 h-10 bg-gradient-to-br from-green-500 to-green-600 rounded-lg flex items-center justify-center flex-shrink-0">
                                    <i class="fas fa-list-check text-white"></i>
                                </div>
                                <div class="text-left">
                                    <p class="font-semibold text-sm text-gray-900">İşlerimi Gör</p>
                                    <p class="text-xs text-gray-600">Tüm işleri listele</p>
                                </div>
                            </button>
                        </div>
                    </div>

                    <!-- Haftalık Durum -->
                    <div class="card p-6">
                        <h3 class="text-lg font-bold text-gray-900 mb-4">📅 Haftalık Durum</h3>
                        <div class="space-y-3">
                            ${generateWeeklyProgress()}
                        </div>
                        <div class="mt-4 pt-4 border-t border-gray-200">
                            <div class="flex items-center justify-between text-sm">
                                <span class="text-gray-600 font-medium">Toplam</span>
                                <span class="font-bold text-gray-900">0h / 40h</span>
                            </div>
                        </div>
                    </div>

                    <!-- Performans Kartı -->
                    <div class="card bg-gradient-to-br from-indigo-600 to-purple-600 text-white p-6">
                        <h3 class="text-lg font-bold mb-4">🏆 Bu Ay Performans</h3>
                        <div class="space-y-3">
                            <div class="flex justify-between items-center">
                                <span class="text-indigo-100">Tamamlanan</span>
                                <span class="font-bold text-xl">0 iş</span>
                            </div>
                            <div class="flex justify-between items-center">
                                <span class="text-indigo-100">Zamanında Bitiş</span>
                                <span class="font-bold text-xl">-%</span>
                            </div>
                            <div class="flex justify-between items-center">
                                <span class="text-indigo-100">Verimlilik</span>
                                <span class="font-bold text-xl">-</span>
                            </div>
                        </div>
                        <div class="mt-4 pt-4 border-t border-indigo-400">
                            <p class="text-xs text-indigo-200">
                                <i class="fas fa-info-circle mr-1"></i>
                                API bağlantısı kurulduğunda gerçek veriler gösterilecek
                            </p>
                        </div>
                    </div>

                </div>

            </div>

        </div>
    `;
}

// ====================================
// YÖNETİCİ DASHBOARD
// ====================================
function loadManagerDashboard(content) {
    content.innerHTML = `
        <div class="animate-fade-in space-y-6">
            
            <!-- Welcome Header -->
            <div class="card p-6 bg-gradient-to-r from-purple-600 to-pink-600 text-white">
                <div class="flex items-center justify-between">
                    <div>
                        <h1 class="text-3xl font-bold mb-2">👨‍💼 Yönetici Dashboard</h1>
                        <p class="text-purple-100">Ekip ve projelerin genel görünümü</p>
                    </div>
                    <div class="text-right">
                        <div class="text-sm text-purple-100">Bugün</div>
                        <div class="text-2xl font-bold">${new Date().toLocaleDateString('tr-TR', { day: 'numeric', month: 'long' })}</div>
                    </div>
                </div>
            </div>

            <!-- Manager Stats -->
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
                
                <!-- Takım Üyeleri -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-blue-500 to-blue-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-users text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-blue-600 bg-blue-50 px-2 py-1 rounded-full">TAKIM</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Takım Üyeleri</h3>
                    <p class="text-3xl font-bold text-gray-900">0</p>
                    <p class="text-xs text-blue-600 mt-2">
                        <i class="fas fa-user-check mr-1"></i>Aktif personel
                    </p>
                </div>

                <!-- Aktif Projeler -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-green-500 to-green-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-folder text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-green-600 bg-green-50 px-2 py-1 rounded-full">PROJE</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Aktif Projeler</h3>
                    <p class="text-3xl font-bold text-gray-900">0</p>
                    <p class="text-xs text-green-600 mt-2">
                        <i class="fas fa-chart-line mr-1"></i>Devam ediyor
                    </p>
                </div>

                <!-- Bekleyen Onaylar -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-orange-500 to-orange-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-clock text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-orange-600 bg-orange-50 px-2 py-1 rounded-full">ONAY</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Bekleyen Onaylar</h3>
                    <p class="text-3xl font-bold text-gray-900">0</p>
                    <p class="text-xs text-orange-600 mt-2">
                        <i class="fas fa-exclamation-triangle mr-1"></i>İncelenmeli
                    </p>
                </div>

                <!-- Geciken İşler -->
                <div class="stats-card card p-6 hover:shadow-lg transition">
                    <div class="flex items-center justify-between mb-4">
                        <div class="w-12 h-12 bg-gradient-to-br from-red-500 to-red-600 rounded-xl flex items-center justify-center shadow-lg">
                            <i class="fas fa-exclamation-circle text-white text-xl"></i>
                        </div>
                        <span class="text-xs font-bold text-red-600 bg-red-50 px-2 py-1 rounded-full">ACİL</span>
                    </div>
                    <h3 class="text-gray-600 text-sm font-semibold mb-1">Geciken İşler</h3>
                    <p class="text-3xl font-bold text-gray-900">0</p>
                    <p class="text-xs text-red-600 mt-2">
                        <i class="fas fa-flag mr-1"></i>Müdahale gerekli
                    </p>
                </div>

            </div>

            <!-- Tabs -->
            <div class="card">
                <div class="border-b border-gray-200">
                    <nav class="flex space-x-8 px-6" role="tablist">
                        <button onclick="switchTab('team')" id="tab-team" class="dashboard-tab active border-b-2 border-blue-600 py-4 px-1 text-sm font-semibold text-blue-600">
                            <i class="fas fa-users mr-2"></i>Takım Durumu
                        </button>
                        <button onclick="switchTab('projects')" id="tab-projects" class="dashboard-tab border-b-2 border-transparent py-4 px-1 text-sm font-semibold text-gray-500 hover:text-gray-700 hover:border-gray-300">
                            <i class="fas fa-folder mr-2"></i>Projeler
                        </button>
                        <button onclick="switchTab('approvals')" id="tab-approvals" class="dashboard-tab border-b-2 border-transparent py-4 px-1 text-sm font-semibold text-gray-500 hover:text-gray-700 hover:border-gray-300">
                            <i class="fas fa-check-circle mr-2"></i>Onaylar
                        </button>
                    </nav>
                </div>

                <!-- Tab Content -->
                <div id="tab-content" class="p-6">
                    ${generateTeamStatus()}
                </div>
            </div>

            <!-- Bottom Grid -->
            <div class="grid grid-cols-1 lg:grid-cols-2 gap-6">
                
                <!-- Proje İlerlemesi -->
                <div class="card p-6">
                    <h3 class="text-lg font-bold text-gray-900 mb-4">📊 Proje İlerlemesi</h3>
                    ${generateProjectProgress()}
                </div>

                <!-- Faturalama Durumu -->
                <div class="card p-6">
                    <h3 class="text-lg font-bold text-gray-900 mb-4">💰 Faturalama Durumu</h3>
                    ${generateBillingStatus()}
                </div>

            </div>

        </div>
    `;

    // Setup tab switching
    setupManagerTabs();
}

// ====================================
// HELPER FUNCTIONS
// ====================================

function generatePriorityTasks() {
    return `
        <div class="text-center py-12 text-gray-500">
            <i class="fas fa-inbox text-5xl mb-3 text-gray-300"></i>
            <p class="text-lg font-medium mb-2">Henüz öncelikli iş bulunmuyor</p>
            <p class="text-sm">API bağlantısı kurulunca işler burada görünecek</p>
            <button onclick="window.location.hash='tasks'" class="mt-4 text-sm text-blue-600 hover:underline">
                <i class="fas fa-plus mr-1"></i>Yeni İş Ekle
            </button>
        </div>
    `;
}

function generateUpcomingDeadlines() {
    return `
        <div class="text-center py-8 text-gray-500">
            <i class="fas fa-calendar-check text-4xl mb-2 text-gray-300"></i>
            <p class="text-sm">Yaklaşan deadline yok</p>
        </div>
    `;
}

function generateRecentActivities() {
    return `
        <div class="p-6 text-center text-gray-500">
            <i class="fas fa-history text-4xl mb-2 text-gray-300"></i>
            <p class="text-sm">Henüz faaliyet kaydı yok</p>
        </div>
    `;
}

function generateWeeklyProgress() {
    const days = ['Pzt', 'Sal', 'Çar', 'Per', 'Cum'];
    return days.map(day => `
        <div class="flex items-center justify-between">
            <span class="text-sm font-medium text-gray-700 w-12">${day}</span>
            <div class="flex-1 mx-3 bg-gray-200 rounded-full h-2 overflow-hidden">
                <div class="h-full bg-gradient-to-r from-blue-500 to-purple-600 rounded-full" style="width: 0%"></div>
            </div>
            <span class="text-xs text-gray-500 w-12 text-right">0h</span>
        </div>
    `).join('');
}

function generateTeamStatus() {
    return `
        <div class="text-center py-12 text-gray-500">
            <i class="fas fa-users text-5xl mb-3 text-gray-300"></i>
            <p class="text-lg font-medium mb-2">Takım verileri yükleniyor</p>
            <p class="text-sm">API bağlantısı kurulunca personel durumları gösterilecek</p>
        </div>
    `;
}

function generateProjectProgress() {
    return `
        <div class="text-center py-8 text-gray-500">
            <i class="fas fa-chart-pie text-4xl mb-2 text-gray-300"></i>
            <p class="text-sm">Proje verileri bekleniyor</p>
        </div>
    `;
}

function generateBillingStatus() {
    return `
        <div class="space-y-3">
            <div class="flex items-center justify-between p-4 bg-green-50 rounded-xl">
                <div class="flex items-center">
                    <i class="fas fa-check-circle text-green-600 text-xl mr-3"></i>
                    <span class="font-medium text-gray-900">Fatura Kesilecek</span>
                </div>
                <span class="text-xl font-bold text-green-600">0</span>
            </div>
            <div class="flex items-center justify-between p-4 bg-yellow-50 rounded-xl">
                <div class="flex items-center">
                    <i class="fas fa-clock text-yellow-600 text-xl mr-3"></i>
                    <span class="font-medium text-gray-900">Test Bekleyen</span>
                </div>
                <span class="text-xl font-bold text-yellow-600">0</span>
            </div>
            <div class="flex items-center justify-between p-4 bg-blue-50 rounded-xl">
                <div class="flex items-center">
                    <i class="fas fa-hourglass-half text-blue-600 text-xl mr-3"></i>
                    <span class="font-medium text-gray-900">Onay Bekleyen</span>
                </div>
                <span class="text-xl font-bold text-blue-600">0</span>
            </div>
        </div>
    `;
}

function setupManagerTabs() {
    window.switchTab = function (tabName) {
        // Remove active class from all tabs
        document.querySelectorAll('.dashboard-tab').forEach(tab => {
            tab.classList.remove('active', 'border-blue-600', 'text-blue-600');
            tab.classList.add('border-transparent', 'text-gray-500');
        });

        // Add active class to clicked tab
        const activeTab = document.getElementById(`tab-${tabName}`);
        if (activeTab) {
            activeTab.classList.add('active', 'border-blue-600', 'text-blue-600');
            activeTab.classList.remove('border-transparent', 'text-gray-500');
        }

        // Update content
        const tabContent = document.getElementById('tab-content');
        if (!tabContent) return;

        switch (tabName) {
            case 'team':
                tabContent.innerHTML = generateTeamStatus();
                break;
            case 'projects':
                tabContent.innerHTML = `
                    <div class="text-center py-12 text-gray-500">
                        <i class="fas fa-folder text-5xl mb-3 text-gray-300"></i>
                        <p class="text-lg font-medium mb-2">Proje listesi</p>
                        <p class="text-sm">API bağlantısı kurulunca projeler gösterilecek</p>
                    </div>
                `;
                break;
            case 'approvals':
                tabContent.innerHTML = `
                    <div class="text-center py-12 text-gray-500">
                        <i class="fas fa-check-circle text-5xl mb-3 text-gray-300"></i>
                        <p class="text-lg font-medium mb-2">Onay bekleyen faaliyetler</p>
                        <p class="text-sm">API bağlantısı kurulunca onaylar gösterilecek</p>
                    </div>
                `;
                break;
        }
    };
}