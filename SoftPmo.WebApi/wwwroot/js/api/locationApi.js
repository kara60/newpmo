import apiClient from './apiClient.js';

class LocationApi {
    constructor() {
        this.endpoint = '/Locations';
    }

    async getAll(params = {}) {
        const defaultParams = {
            PageNumber: 1,
            PageSize: 100,
            IsActive: true,
            Search: ''
        };
        const queryParams = { ...defaultParams, ...params };
        return await apiClient.get(this.endpoint, queryParams);
    }

    async getById(id) {
        return await apiClient.get(`${this.endpoint}/${id}`);
    }

    async create(data) {
        return await apiClient.post(`${this.endpoint}/Create`, data);
    }

    async update(data) {
        return await apiClient.put(`${this.endpoint}/Update`, data);
    }

    async delete(id) {
        return await apiClient.delete(`${this.endpoint}/${id}`);
    }
}

const locationApi = new LocationApi();
export default locationApi;