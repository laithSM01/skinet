<template>
  <div class="container">
    <div class="row">
      <section class="col-3">
        <h5 class="text-warning ms-3">Sort</h5>
        <select class="form-select mb-4" @change="onSortSelected($event.target.value)">
          <option v-for="sort in sortOptions" :value="sort.value">
            {{ sort.name }}
          </option>
        </select>
        <h5 class="text-warning ms-3">Brands</h5>
        <ul class="list-group my-3">
          <li
            class="list-group-item"
            v-for="brand in brands"
            :class="{ active: brand.id === shopParams.brandId }"
            @click="onBrandSelected(brand.id)"
          >
            {{ brand.name }}
          </li>
        </ul>
        <h5 class="text-warning ms-3">Types</h5>
        <ul class="list-group my-3">
          <li
            class="list-group-item"
            aria-current="true"
            v-for="type in types"
            :class="{ active: type.id === shopParams.typeId }"
            @click="onTypeSelected(type.id)"
          >
            {{ type.name }})
          </li>
        </ul>
      </section>
      <!--///-->
      <section class="col-9">
        <div class="d-flex justify-content-between align-items-center pb-2">
          <app-paging-header
            :shop-params="shopParams"
            :total-count="totalCount"
          />
          <div class="form-inline mt-2">
            <input
            v-model="shopParams.search"
              type="text"
              class="form-control"
              style="width: 300px"
              placeholder="Search"
            />
            <button @click="onSearch()" class="btn btn-outline-primary my-2">Search</button>
            <button @click="onReset()"  class="btn btn-outline-primary ml-2 my-2">Reset</button>
          </div>
        </div>
        <div class="album py-5 bg-light">
          <div class="container">
            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
              <div v-for="product in products" :key="product.id" class="col-4">
                <app-product-item :product="product" />
              </div>
            </div>
            <div v-if="totalCount != 0">
      <app-pager :total-count="totalCount" :shop-params="shopParams" @changePage="onPageChange"/>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>
<script>
import shopService from "../service/shop.service";
import productItem from "../components/product-item.vue";
import Pager from "@/shared/components/Pager.vue";
import PaginHeader from "@/shared/components/pagin-header.vue";
export default {
  data() {
    return {
      products: [],
      brands: [],
      types: [],
      sortOptions: [
        { name: "Alphabetical", value: "name" },
        { name: "Price Low to High", value: "priceAsc" },
        { name: "Price High to Low", value: "priceDesc" },
      ],
      totalCount: 0,
      shopParams: {
        brandId: 0,
        typeId: 0,
        sort: "name",
        pageNumber: 1,
        pageSize: 6,
        search: ''
      },
    };
  },
  components: {
    appProductItem: productItem,
    appPager: Pager,
    appPagingHeader: PaginHeader,
  },
  methods: {
    getProducts() {
      shopService
        .getProducts(this.shopParams)
        .then((response) => {
          this.products = response.data;
          this.shopParams.pageNumber = response.pageIndex;
          this.shopParams.pageSize = response.pageSize;
          this.totalCount = response.count;
        })
        .catch((error) => {
          console.error("Error fetching products:", error);
        });
    },
    getBrands() {
      shopService.getProductBrand().then((res) => {
        this.brands = res.data;
      });
    },
    getTypes() {
      shopService.getProductTypes().then((res) => {
        this.types = res.data;
      });
    },
    onBrandSelected(brandId) {
      this.shopParams.brandId = this.shopParams.brandId === brandId ? 0 : brandId;
       this.shopParams.pageNumber = 1;
      this.getProducts();
    },
    onTypeSelected(typeId) {
      this.shopParams.typeId = this.shopParams.typeId === typeId ? 0 : typeId;
      this.shopParams.pageNumber = 1;
      this.getProducts();
    },
    onSortSelected(sort) {
      this.shopParams.sort = sort;
      this.getProducts();
    },
    onPageChange(event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    },
    onSearch() {
      this.shopParams.search
      this.getProducts()
    },
    onReset() {
      this.shopParams.search = ''
      this.getProducts()
    }
  },
  created() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  },
};
</script>
<style></style>
