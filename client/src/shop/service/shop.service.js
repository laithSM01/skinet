
import axios from 'axios';
 class ShopService {
    static get baseUrl() {
        return "http://localhost:5212/api/";
      }

    static  getProducts(shopParams) {
      let params = new URLSearchParams();
      if(shopParams.brandId) {
        params.append('brandId', shopParams.brandId)
      }
      if(shopParams.typeId) {
        params.append('typeId', shopParams.typeId)
      }
      params.append('sort', shopParams.sort)
      params.append('pageIndex', shopParams.pageNumber)
      params.append('pageSize', shopParams.pageSize)
      if(shopParams.search) {
        params.append('search', shopParams.search)
      }
      return axios.get(this.baseUrl + 'Products', {params})
        .then(response => {
          return response.data
        })
    }
    static  getProductBrand() {
        return axios.get(this.baseUrl + 'Products/brands')
    }
    static  getProductTypes() {
        return axios.get(this.baseUrl + 'Products/types')
    }
    static async getProduct(id) {
      return await axios.get(this.baseUrl + `Products/${id}`)
    }
}
export default ShopService; 
