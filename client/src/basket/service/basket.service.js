import axios from 'axios';

import Vue from "vue";

class BasketService {
  static baseUrl = "http://localhost:5212/api/";

  static async getBasket(id) {
    try {
      const response = await axios.get(`${this.baseUrl}basket?id=${id}`)
      return response.data;
    } catch (error) {
      console.error('Error fetching basket:', error);
      throw error;
    }
  }

  static async setBasket(basket) {
    try {
      const response = await axios.post(`${this.baseUrl}basket`, basket);
      return response.data;
    } catch (error) {
      console.error('Error setting basket:', error);
      throw error;
    }
  }

  static async deleteBasket(basket) {
    try {
      await axios.delete(`${this.baseUrl}basket?id=${basket.id}`);
      localStorage.removeItem('basket_id');
    } catch (error) {
      console.error('Error deleting basket:', error);
      throw error;
    }
  }
}

export default BasketService;