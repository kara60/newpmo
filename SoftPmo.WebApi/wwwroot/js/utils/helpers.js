// ====================================
// HELPER FUNCTIONS
// ====================================

/**
 * Format date to Turkish format
 */
export function formatDate(date, includeTime = false) {
    if (!date) return '-';

    const d = new Date(date);

    if (isNaN(d.getTime())) return '-';

    const options = {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit'
    };

    if (includeTime) {
        options.hour = '2-digit';
        options.minute = '2-digit';
    }

    return d.toLocaleDateString('tr-TR', options);
}

/**
 * Format date to ISO string for API
 */
export function formatDateForApi(date) {
    if (!date) return null;

    const d = new Date(date);

    if (isNaN(d.getTime())) return null;

    return d.toISOString();
}

/**
 * Debounce function
 */
export function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

/**
 * Show loading state
 */
export function showLoading(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.innerHTML = `
            <div class="flex items-center justify-center py-12">
                <div class="spinner w-10 h-10"></div>
            </div>
        `;
    }
}

/**
 * Truncate text
 */
export function truncate(text, length = 50) {
    if (!text) return '-';
    return text.length > length ? text.substring(0, length) + '...' : text;
}

/**
 * Get status badge HTML
 */
export function getStatusBadge(isActive) {
    if (isActive) {
        return `<span class="inline-flex items-center px-3 py-1 rounded-full text-xs font-bold bg-gradient-to-r from-green-500 to-green-600 text-white shadow-sm">
            <i class="fas fa-circle text-xs mr-1.5 animate-pulse"></i>Aktif
        </span>`;
    } else {
        return `<span class="inline-flex items-center px-3 py-1 rounded-full text-xs font-bold bg-gray-100 text-gray-700">
            <i class="fas fa-circle text-xs mr-1.5"></i>Pasif
        </span>`;
    }
}

/**
 * Confirm dialog
 */
export function confirmDialog(message, onConfirm) {
    const result = confirm(message);
    if (result && onConfirm) {
        onConfirm();
    }
    return result;
}

/**
 * Escape HTML
 */
export function escapeHtml(text) {
    const map = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#039;'
    };
    return text.replace(/[&<>"']/g, m => map[m]);
}

/**
 * Generate UUID
 */
export function generateUUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        const r = Math.random() * 16 | 0;
        const v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

/**
 * Copy to clipboard
 */
export async function copyToClipboard(text) {
    try {
        await navigator.clipboard.writeText(text);
        return true;
    } catch (err) {
        console.error('Failed to copy:', err);
        return false;
    }
}

/**
 * Download as JSON
 */
export function downloadJSON(data, filename) {
    const json = JSON.stringify(data, null, 2);
    const blob = new Blob([json], { type: 'application/json' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `${filename}.json`;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}