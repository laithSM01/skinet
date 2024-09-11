import axios from 'axios';
import { v4 as uuidv4 } from 'uuid';
import Vue from "vue";

class BasketService {
  static baseUrl = "http://localhost:5212/api/";
  // sxtatic basketState = this.$store.state.basket;
  static state = Vue.observable({
    basket: { items: [] },
  });
  static async getBasket(id) {
    try {
      const response = await axios.get(`${this.baseUrl}basket?id=${id}`);
      return response.data;
    } catch (error) {
      console.error('Error fetching basket:', error);
      throw error;
    }
  }

  static async setBasket(basket) {
    
    try {
      console.log(basket)
      const response = await axios.post(`${this.baseUrl}basket`, basket);
      localStorage.setItem('basket_id', basket.id);
      return response.data;
    } catch (error) {
      console.error('Error setting basket:', error);
      throw error;
    }
  }

  static getCurrentBasketValue() {
    return BasketService.state.basket;
  }

  static async addItemToBasket(item, quantity = 1) {
    let basket = this.getCurrentBasketValue() || { items: [] };

    // Check if the item is a product object, and map it to a basket item if needed
    if (this.isProduct(item)) {
        item = this.mapProductItemToBasketItem(item);
    }
    // Check if the item already exists in the basket
    const existingItemIndex = basket.items.findIndex(i => i.id === item.id);
    console.log("existingItemIndex",existingItemIndex)


    if (existingItemIndex !== -1) {
        // Increase the quantity if the item exists
        basket.items[existingItemIndex].quantity += quantity;
    } else {
        // Add the item to the basket with the specified quantity
        item.quantity = quantity;
        basket.items.push(item);
    }
    if (!basket.id) {
        basket.id = uuidv4(); // Generate UUID if ID is missing
      }
      console.log("and finally :D",basket)
    // Update the basket with the modified items array
    await this.setBasket(basket);
}

  static async removeItemFromBasket(id, quantity = 1) {
    let basket = this.getCurrentBasketValue();
    
    if (!basket) return;

    const itemIndex = basket.items.findIndex(i => i.id === id);

    if (itemIndex !== -1) {
      basket.items[itemIndex].quantity -= quantity;

      if (basket.items[itemIndex].quantity <= 0) {
        basket.items.splice(itemIndex, 1);
      }

      if (basket.items.length > 0) {
        await this.setBasket(basket);
      } else {
        await this.deleteBasket(basket);
      }
    }
  }

  static async deleteBasket(basket) {
    try {
      await axios.delete(`${this.baseUrl}basket?id=${basket.id}`);
      localStorage.removeItem('basket');
    } catch (error) {
      console.error('Error deleting basket:', error);
      throw error;
    }
  }

  static mapProductItemToBasketItem(item) {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      quantity: 0,
      pictureUrl: item.pictureUrl,
      brand: item.productBrand,
      type: item.productType
    };
  }

  static isProduct(item) {
    return item.productBrand !== undefined;
  }

  static async calculateTotals() {
    let basket = this.getCurrentBasketValue();

    if (!basket) return;

    const shipping = 0;
    const subtotal = basket.items.reduce((acc, item) => acc + item.price * item.quantity, 0);
    const total = subtotal + shipping;

    return { shipping, total, subtotal };
  }
}

export default BasketService;