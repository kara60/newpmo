// ====================================
// MODERN MODAL COMPONENT
// ====================================

export class Modal {
    constructor(title, content, options = {}) {
        this.title = title;
        this.content = content;
        this.options = {
            size: options.size || 'md', // sm, md, lg, xl, full
            mode: options.mode || 'view', // view, edit, create
            showCloseButton: options.showCloseButton !== false,
            closeOnBackdrop: options.closeOnBackdrop !== false,
            footer: options.footer || null,
            onClose: options.onClose || null,
            onEdit: options.onEdit || null,
            onSave: options.onSave || null,
            data: options.data || null
        };
        this.element = null;
        this.isOpen = false;
        this.currentMode = this.options.mode;
    }

    open() {
        if (this.isOpen) return;

        const sizes = {
            sm: 'max-w-md',
            md: 'max-w-2xl',
            lg: 'max-w-4xl',
            xl: 'max-w-6xl',
            full: 'max-w-7xl'
        };

        const modeColors = {
            view: 'from-indigo-500 to-purple-600',
            edit: 'from-orange-500 to-red-600',
            create: 'from-green-500 to-teal-600'
        };

        const modeIcons = {
            view: 'fa-eye',
            edit: 'fa-edit',
            create: 'fa-plus-circle'
        };

        const modeTexts = {
            view: 'İNCELE',
            edit: 'DÜZENLE',
            create: 'YENİ'
        };

        const modalHTML = `
            <div class="fixed inset-0 z-50 overflow-y-auto animate-fade-in" id="modal-overlay">
                <div class="flex items-center justify-center min-h-screen px-4 pt-4 pb-20">
                    
                    <!-- Backdrop -->
                    <div class="fixed inset-0 bg-gray-900/50 backdrop-blur-sm transition-opacity" 
                         ${this.options.closeOnBackdrop ? 'onclick="window.currentModal?.close()"' : ''}></div>

                    <!-- Modal -->
                    <div class="modal-container relative ${sizes[this.options.size]} w-full animate-scale-in">
                        
                        <!-- Header -->
                        <div class="relative bg-gradient-to-r ${modeColors[this.currentMode]} text-white px-8 py-6">
                            
                            <!-- Mode Indicator -->
                            <div class="absolute top-4 right-4 flex items-center space-x-2">
                                <span class="mode-indicator mode-${this.currentMode} flex items-center space-x-2">
                                    <i class="fas ${modeIcons[this.currentMode]} text-xs"></i>
                                    <span>${modeTexts[this.currentMode]}</span>
                                </span>
                            </div>

                            <!-- Title -->
                            <h3 class="text-2xl font-bold mb-2">${this.title}</h3>
                            <p class="text-white/80 text-sm">
                                ${this.currentMode === 'view' ? 'Detayları görüntüleyin' :
                this.currentMode === 'edit' ? 'Bilgileri düzenleyin' :
                    'Yeni kayıt oluşturun'}
                            </p>

                            ${this.options.showCloseButton ? `
                                <button onclick="window.currentModal?.close()" 
                                    class="absolute top-6 right-20 text-white/80 hover:text-white transition">
                                    <i class="fas fa-times text-xl"></i>
                                </button>
                            ` : ''}
                        </div>

                        <!-- Content -->
                        <div class="bg-white px-8 py-6 max-h-[70vh] overflow-y-auto">
                            <div id="modal-content-container">
                                ${this.content}
                            </div>
                        </div>

                        <!-- Footer -->
                        <div class="bg-gray-50 px-8 py-4 flex items-center justify-between border-t border-gray-200">
                            <div class="text-sm text-gray-500">
                                ${this.currentMode === 'view' ?
                '<i class="fas fa-info-circle mr-2"></i>Salt okunur mod' :
                this.currentMode === 'edit' ?
                    '<i class="fas fa-exclamation-triangle mr-2"></i>Değişiklikler kaydedilecek' :
                    '<i class="fas fa-plus-circle mr-2"></i>Yeni kayıt eklenecek'}
                            </div>
                            <div class="flex items-center space-x-3">
                                ${this.getFooterButtons()}
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        `;

        const modalContainer = document.createElement('div');
        modalContainer.innerHTML = modalHTML;
        document.body.appendChild(modalContainer.firstElementChild);

        this.element = document.getElementById('modal-overlay');
        this.isOpen = true;
        window.currentModal = this;

        document.body.style.overflow = 'hidden';

        // Setup form state
        this.setupFormState();
    }

    getFooterButtons() {
        if (this.currentMode === 'view') {
            return `
                <button onclick="window.currentModal?.close()" 
                    class="px-5 py-2.5 border-2 border-gray-300 rounded-xl text-gray-700 hover:bg-gray-100 transition font-medium">
                    <i class="fas fa-times mr-2"></i>Kapat
                </button>
                ${this.options.onEdit ? `
                    <button onclick="window.currentModal?.switchToEditMode()" 
                        class="px-5 py-2.5 bg-gradient-to-r from-blue-600 to-blue-700 text-white rounded-xl hover:from-blue-700 hover:to-blue-800 transition font-medium shadow-lg">
                        <i class="fas fa-edit mr-2"></i>Düzenle
                    </button>
                ` : ''}
            `;
        } else {
            return `
                <button onclick="window.currentModal?.close()" 
                    class="px-5 py-2.5 border-2 border-gray-300 rounded-xl text-gray-700 hover:bg-gray-100 transition font-medium">
                    <i class="fas fa-times mr-2"></i>İptal
                </button>
                <button onclick="window.currentModal?.save()" 
                    class="px-5 py-2.5 bg-gradient-to-r from-green-600 to-green-700 text-white rounded-xl hover:from-green-700 hover:to-green-800 transition font-medium shadow-lg">
                    <i class="fas fa-save mr-2"></i>Kaydet
                </button>
            `;
        }
    }

    setupFormState() {
        const form = this.element.querySelector('form');
        if (!form) return;

        const inputs = form.querySelectorAll('input, select, textarea');
        inputs.forEach(input => {
            if (this.currentMode === 'view') {
                input.disabled = true;
                input.classList.add('bg-gray-50', 'cursor-not-allowed');
            } else {
                input.disabled = false;
                input.classList.remove('bg-gray-50', 'cursor-not-allowed');
            }
        });
    }

    switchToEditMode() {
        this.currentMode = 'edit';
        this.close();

        // Re-open in edit mode
        setTimeout(() => {
            this.options.mode = 'edit';
            this.open();

            if (this.options.onEdit) {
                this.options.onEdit();
            }
        }, 100);
    }

    async save() {
        if (this.options.onSave) {
            const result = await this.options.onSave();
            if (result !== false) {
                this.close();
            }
        } else {
            this.close();
        }
    }

    close() {
        if (!this.isOpen || !this.element) return;

        this.element.classList.add('opacity-0');
        setTimeout(() => {
            this.element.remove();
            this.isOpen = false;
            document.body.style.overflow = '';
            window.currentModal = null;

            if (this.options.onClose) {
                this.options.onClose();
            }
        }, 200);
    }

    updateContent(newContent) {
        const container = document.getElementById('modal-content-container');
        if (container) {
            container.innerHTML = newContent;
            this.setupFormState();
        }
    }
}

/**
 * Confirm Modal
 */
export function showConfirmModal(title, message, onConfirm, options = {}) {
    const content = `
        <div class="text-center py-8">
            <div class="w-16 h-16 bg-red-100 rounded-full flex items-center justify-center mx-auto mb-4">
                <i class="fas fa-exclamation-triangle text-red-600 text-2xl"></i>
            </div>
            <p class="text-gray-700 text-lg">${message}</p>
        </div>
    `;

    const modal = new Modal(title, content, {
        size: 'sm',
        mode: 'view',
        showCloseButton: true,
        onSave: async () => {
            if (onConfirm) {
                await onConfirm();
            }
            return true;
        },
        ...options
    });

    // Override footer for confirm dialog
    modal.getFooterButtons = () => `
        <button onclick="window.currentModal?.close()" 
            class="px-5 py-2.5 border-2 border-gray-300 rounded-xl text-gray-700 hover:bg-gray-100 transition font-medium">
            <i class="fas fa-times mr-2"></i>İptal
        </button>
        <button onclick="window.currentModal?.save()" 
            class="px-5 py-2.5 bg-gradient-to-r from-red-600 to-red-700 text-white rounded-xl hover:from-red-700 hover:to-red-800 transition font-medium shadow-lg">
            <i class="fas fa-check mr-2"></i>Onayla
        </button>
    `;

    modal.open();
}

/**
 * Success Modal
 */
export function showSuccessModal(title, message) {
    const content = `
        <div class="text-center py-8">
            <div class="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
                <i class="fas fa-check-circle text-green-600 text-2xl"></i>
            </div>
            <p class="text-gray-700 text-lg">${message}</p>
        </div>
    `;

    const modal = new Modal(title, content, {
        size: 'sm',
        mode: 'view',
        showCloseButton: true
    });

    modal.getFooterButtons = () => `
        <button onclick="window.currentModal?.close()" 
            class="px-5 py-2.5 bg-gradient-to-r from-green-600 to-green-700 text-white rounded-xl hover:from-green-700 hover:to-green-800 transition font-medium shadow-lg">
            <i class="fas fa-check mr-2"></i>Tamam
        </button>
    `;

    modal.open();
}