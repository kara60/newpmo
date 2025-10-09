// ====================================
// MAIN APP ENTRY POINT
// ====================================

import { Router } from './utils/router.js';
import { showToast } from './utils/toast.js';
import { loadDashboard } from './pages/dashboard.js';
import { loadLocations } from './pages/locations.js';
import { loadDepartments } from './pages/departments.js';
import { loadPositions } from './pages/positions.js';
//import { loadPositionLevels } from './pages/positionLevels.js';
import { loadLocationTypes } from './pages/locationTypes.js';
import { loadCustomers } from './pages/customers.js';
import { loadProjects } from './pages/projects.js';
import { loadUsers } from './pages/users.js';
import { loadTasks } from './pages/tasks.js';
import { loadNotifications } from './pages/notifications.js';
import { loadPriorities } from './pages/priorities.js';
import { loadSteps } from './pages/steps.js';
import { loadTaskTypes } from './pages/taskTypes.js';
import { loadTaskStatuses } from './pages/taskStatuses.js';
import { loadProjectTypes } from './pages/projectTypes.js';
import { loadProjectStatuses } from './pages/projectStatuses.js';
import { loadProjectRoles } from './pages/projectRoles.js';

class App {
    constructor() {
        this.router = new Router();
        this.init();
    }

    async init() {
        console.log('🚀 PMO System initializing...');

        this.setupRoutes();
        this.setupUI();
        this.setupOfflineDetection();

        // Hide loading screen
        setTimeout(() => {
            const loadingScreen = document.getElementById('loading-screen');
            const app = document.getElementById('app');

            if (loadingScreen && app) {
                loadingScreen.classList.add('hidden');
                app.classList.remove('hidden');
                this.router.handleRoute();
            }
        }, 500);
    }

    setupRoutes() {
        console.log('📋 Setting up routes...');

        // ============================================
        // DASHBOARD
        // ============================================
        this.router.register('dashboard', () => {
            loadDashboard();
            this.setActiveLink('dashboard');
        });

        // ============================================
        // İŞ YÖNETİMİ
        // ============================================
        this.router.register('tasks', () => {
            loadTasks();
            this.setActiveLink('tasks');
        });

        this.router.register('all-tasks', () => {
            loadTasks();
            this.setActiveLink('all-tasks');
        });

        this.router.register('my-activities', () => {
            loadNotifications();
            this.setActiveLink('my-activities');
        });

        this.router.register('activity-approvals', () => {
            loadNotifications();
            this.setActiveLink('activity-approvals');
        });

        // ============================================
        // PROJE YÖNETİMİ
        // ============================================
        this.router.register('projects', () => {
            loadProjects();
            this.setActiveLink('projects');
        });

        this.router.register('customers', () => {
            loadCustomers();
            this.setActiveLink('customers');
        });

        this.router.register('users', () => {
            loadUsers();
            this.setActiveLink('users');
        });

        // ============================================
        // TANIMLAMA EKRANLARI
        // ============================================

        // Lokasyon
        this.router.register('locations', () => {
            loadLocations();
            this.setActiveLink('locations');
        });

        this.router.register('location-types', () => {
            loadLocationTypes();
            this.setActiveLink('location-types');
        });

        // Departman & Pozisyon
        this.router.register('departments', () => {
            loadDepartments();
            this.setActiveLink('departments');
        });

        this.router.register('position-levels', () => {
            loadPositionLevels();
            this.setActiveLink('position-levels');
        });

        this.router.register('positions', () => {
            loadPositions();
            this.setActiveLink('positions');
        });

        // İş Tanımları
        this.router.register('task-types', () => {
            loadTaskTypes();
            this.setActiveLink('task-types');
        });

        this.router.register('task-status-types', () => {
            loadTaskStatuses();
            this.setActiveLink('task-status-types');
        });

        this.router.register('task-statuses', () => {
            loadTaskStatuses();
            this.setActiveLink('task-statuses');
        });

        this.router.register('priorities', () => {
            loadPriorities();
            this.setActiveLink('priorities');
        });

        this.router.register('steps', () => {
            loadSteps();
            this.setActiveLink('steps');
        });

        // Proje Tanımları
        this.router.register('project-types', () => {
            loadProjectTypes();
            this.setActiveLink('project-types');
        });

        this.router.register('project-statuses', () => {
            loadProjectStatuses();
            this.setActiveLink('project-statuses');
        });

        this.router.register('project-roles', () => {
            loadProjectRoles();
            this.setActiveLink('project-roles');
        });
    }

    setupUI() {
        console.log('🎨 Setting up UI components...');

        // ============================================
        // MOBILE MENU TOGGLE
        // ============================================
        const mobileMenuBtn = document.getElementById('mobile-menu-btn');
        const sidebar = document.getElementById('sidebar');
        const sidebarBackdrop = document.getElementById('sidebar-backdrop');
        const sidebarClose = document.getElementById('sidebar-close');

        if (mobileMenuBtn && sidebar && sidebarBackdrop) {
            // Open sidebar
            mobileMenuBtn.addEventListener('click', () => {
                sidebar.classList.add('open');
                sidebarBackdrop.classList.add('show');
                document.body.style.overflow = 'hidden';
            });

            // Close sidebar
            const closeSidebar = () => {
                sidebar.classList.remove('open');
                sidebarBackdrop.classList.remove('show');
                document.body.style.overflow = '';
            };

            sidebarClose?.addEventListener('click', closeSidebar);
            sidebarBackdrop.addEventListener('click', closeSidebar);

            // Close sidebar on navigation (mobile)
            document.querySelectorAll('.sidebar-link').forEach(link => {
                link.addEventListener('click', () => {
                    if (window.innerWidth < 1024) {
                        closeSidebar();
                    }
                });
            });
        }

        // ============================================
        // SUBMENU TOGGLE (Tanımlamalar)
        // ============================================
        const toggleDefinitions = document.getElementById('toggle-definitions');
        const submenuDefinitions = document.getElementById('submenu-definitions');

        if (toggleDefinitions && submenuDefinitions) {
            toggleDefinitions.addEventListener('click', () => {
                submenuDefinitions.classList.toggle('open');
                const icon = toggleDefinitions.querySelector('i');
                if (icon) {
                    icon.classList.toggle('rotate-180');
                }
            });
        }

        // ============================================
        // NAVIGATION LINKS
        // ============================================
        document.querySelectorAll('.sidebar-link').forEach(link => {
            link.addEventListener('click', (e) => {
                e.preventDefault();
                const href = e.currentTarget.getAttribute('href');
                if (href && href.startsWith('#')) {
                    const route = href.substring(1);
                    this.router.navigate(route);
                }
            });
        });

        // ============================================
        // FULLSCREEN TOGGLE
        // ============================================
        const fullscreenBtn = document.getElementById('fullscreen-btn');
        if (fullscreenBtn) {
            fullscreenBtn.addEventListener('click', () => {
                if (!document.fullscreenElement) {
                    document.documentElement.requestFullscreen();
                } else {
                    document.exitFullscreen();
                }
            });
        }
    }

    setupOfflineDetection() {
        console.log('📡 Setting up offline detection...');

        window.addEventListener('offline', () => {
            showToast('❌ İnternet bağlantısı kesildi', 'error');
        });

        window.addEventListener('online', () => {
            showToast('✅ İnternet bağlantısı geri geldi', 'success');
        });

        // Initial check
        if (!navigator.onLine) {
            showToast('⚠️ Çevrimdışı modasınız', 'warning');
        }
    }

    setActiveLink(route) {
        // Remove active class from all links
        document.querySelectorAll('.sidebar-link').forEach(link => {
            link.classList.remove('active');
        });

        // Add active class to current route
        const activeLink = document.querySelector(`.sidebar-link[href="#${route}"]`);
        if (activeLink) {
            activeLink.classList.add('active');
        }
    }
}

// ============================================
// INITIALIZE APP
// ============================================
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', () => {
        console.log('📱 DOM Content Loaded');
        window.app = new App();
    });
} else {
    console.log('📱 Document already loaded');
    window.app = new App();
}

// ============================================
// GLOBAL ERROR HANDLER
// ============================================
window.addEventListener('error', (event) => {
    console.error('❌ Global error:', event.error);
    showToast('Bir hata oluştu. Lütfen sayfayı yenileyin.', 'error');
});

window.addEventListener('unhandledrejection', (event) => {
    console.error('❌ Unhandled promise rejection:', event.reason);
    showToast('Bir işlem başarısız oldu.', 'error');
});

console.log('✅ App.js loaded successfully');