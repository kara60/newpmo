// ====================================
// TOAST NOTIFICATION SYSTEM
// ====================================

export function showToast(message, type = 'info', duration = 3000) {
    const container = document.getElementById('toast-container');

    if (!container) {
        console.error('Toast container not found');
        return;
    }

    const colors = {
        success: 'bg-green-500',
        error: 'bg-red-500',
        warning: 'bg-yellow-500',
        info: 'bg-blue-500'
    };

    const icons = {
        success: 'fa-check-circle',
        error: 'fa-times-circle',
        warning: 'fa-exclamation-triangle',
        info: 'fa-info-circle'
    };

    const id = Date.now();

    const toast = document.createElement('div');
    toast.id = `toast-${id}`;
    toast.className = `${colors[type]} text-white px-6 py-3 rounded-lg shadow-lg flex items-center space-x-3 transform transition-all duration-300 translate-x-full`;
    toast.innerHTML = `
        <i class="fas ${icons[type]} text-lg"></i>
        <span class="font-medium flex-1">${message}</span>
        <button onclick="document.getElementById('toast-${id}').remove()" 
            class="hover:bg-white/20 rounded p-1 transition">
            <i class="fas fa-times text-sm"></i>
        </button>
    `;

    container.appendChild(toast);

    // Animate in
    setTimeout(() => {
        toast.classList.remove('translate-x-full');
    }, 10);

    // Auto remove
    setTimeout(() => {
        toast.classList.add('translate-x-full');
        setTimeout(() => toast.remove(), 300);
    }, duration);
}

// Global access
window.showToast = showToast;