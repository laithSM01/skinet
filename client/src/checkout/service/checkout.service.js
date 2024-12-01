import axios from 'axios';

class CheckOutService {
    static get baseUrl() {
        return "https://localhost:5212/api/";
      }
      
      static async getDeliveryMethods() {
        try {
          const response = await axios.get(`${this.baseUrl}Orders/deliveryMethods`);
          return response.data.map(x => x).sort((a, b) => b.price - a.price);
      } catch (error) {
          console.error("Error fetching delivery methods:", error);
          throw error;
      }
      }

      static async createOrder(data) {
        const order = await axios.post(`${this.baseUrl}Orders`, data);
        return order;
      }
}
export default  CheckOutService;