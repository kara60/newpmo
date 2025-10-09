import apiClient from './apiClient.js';

class PositionApi {
    constructor() {
        this.endpoint = '/Positions';
    }

    /**
     * Get all positions with filters
     */
    async getAll(params = {}) {
        const defaultParams = {
            PageNumber: 1,
            PageSize: 100,  // Hepsini getir
            IsActive: true,
            Search: '',
            DepartmentId: '',
            PositionLevelId: ''
        };

        const queryParams = { ...defaultParams, ...params };
        return await apiClient.get(this.endpoint, queryParams);
    }

    /**
     * Get position by ID
     */
    async getById(id) {
        return await apiClient.get(`${this.endpoint}/${id}`);
    }

    /**
     * Create new position
     */
    async create(data) {
        return await apiClient.post(`${this.endpoint}/Create`, data);
    }

    /**
     * Update position
     */
    async update(data) {
        return await apiClient.put(`${this.endpoint}/Update`, data);
    }

    /**
     * Delete position
     */
    async delete(id) {
        return await apiClient.delete(`${this.endpoint}/${id}`);
    }
}

const positionApi = new PositionApi();
export default positionApi;