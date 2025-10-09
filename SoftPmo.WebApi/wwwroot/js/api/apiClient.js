// ====================================
// BASE API CLIENT
// ====================================

class ApiClient {
    constructor() {
        // API Base URL (aynı domain olduğu için relative)
        this.baseURL = '/api';

        // Default headers
        this.headers = {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        };
    }

    /**
     * Generic GET request
     */
    async get(endpoint, params = null) {
        try {
            let url = `${this.baseURL}${endpoint}`;

            // Add query params if exists
            if (params) {
                const queryString = new URLSearchParams(params).toString();
                url += `?${queryString}`;
            }

            const response = await fetch(url, {
                method: 'GET',
                headers: this.headers
            });

            return await this.handleResponse(response);
        } catch (error) {
            return this.handleError(error);
        }
    }

    /**
     * Generic POST request
     */
    async post(endpoint, data) {
        try {
            const response = await fetch(`${this.baseURL}${endpoint}`, {
                method: 'POST',
                headers: this.headers,
                body: JSON.stringify(data)
            });

            return await this.handleResponse(response);
        } catch (error) {
            return this.handleError(error);
        }
    }

    /**
     * Generic PUT request
     */
    async put(endpoint, data) {
        try {
            const response = await fetch(`${this.baseURL}${endpoint}`, {
                method: 'PUT',
                headers: this.headers,
                body: JSON.stringify(data)
            });

            return await this.handleResponse(response);
        } catch (error) {
            return this.handleError(error);
        }
    }

    /**
     * Generic DELETE request
     */
    async delete(endpoint) {
        try {
            const response = await fetch(`${this.baseURL}${endpoint}`, {
                method: 'DELETE',
                headers: this.headers
            });

            return await this.handleResponse(response);
        } catch (error) {
            return this.handleError(error);
        }
    }

    /**
     * Handle API Response
     */
    async handleResponse(response) {
        // Get response text first
        const text = await response.text();

        // Try to parse JSON
        let data = null;
        try {
            data = text ? JSON.parse(text) : null;
        } catch (e) {
            data = text;
        }

        // Check if response is ok
        if (!response.ok) {
            const error = {
                status: response.status,
                statusText: response.statusText,
                message: data?.message || data?.title || 'Bir hata oluştu',
                errors: data?.errors || null,
                data: data
            };
            throw error;
        }

        return {
            success: true,
            data: data,
            status: response.status
        };
    }

    /**
     * Handle Errors
     */
    handleError(error) {
        console.error('API Error:', error);

        // Network error
        if (error instanceof TypeError) {
            return {
                success: false,
                message: 'Sunucuya bağlanılamadı. İnternet bağlantınızı kontrol edin.',
                error: error
            };
        }

        // API error
        return {
            success: false,
            message: error.message || 'Bir hata oluştu',
            status: error.status,
            errors: error.errors,
            error: error
        };
    }

    /**
     * Set Authorization Token (for future use)
     */
    setAuthToken(token) {
        if (token) {
            this.headers['Authorization'] = `Bearer ${token}`;
        } else {
            delete this.headers['Authorization'];
        }
    }
}

// Create singleton instance
const apiClient = new ApiClient();

// Export
export default apiClient;