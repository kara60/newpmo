// ====================================
// SIMPLE HASH-BASED ROUTER
// ====================================

export class Router {
    constructor() {
        this.routes = {};
        this.currentRoute = null;

        console.log('Router initialized');

        // Listen to hash changes
        window.addEventListener('hashchange', () => {
            console.log('Hash changed to:', window.location.hash);
            this.handleRoute();
        });
    }

    register(path, handler) {
        this.routes[path] = handler;
        console.log('Route registered:', path);
    }

    navigate(path) {
        console.log('Navigating to:', path);
        window.location.hash = path;
    }

    handleRoute() {
        // Get hash without #
        let hash = window.location.hash.substring(1);

        // Default to dashboard if no hash
        if (!hash) {
            hash = 'dashboard';
            window.location.hash = 'dashboard';
        }

        console.log('Handling route:', hash);

        const handler = this.routes[hash];

        if (handler) {
            this.currentRoute = hash;
            console.log('Calling handler for:', hash);
            handler();
        } else {
            console.warn(`Route not found: ${hash}, redirecting to dashboard`);
            this.navigate('dashboard');
        }
    }

    getCurrentRoute() {
        return this.currentRoute;
    }
}