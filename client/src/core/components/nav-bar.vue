<template>
  <div>
<nav class="navbar navbar-expand-lg bg-body-tertiary box">
  <div class="container-fluid">
    <router-link class="navbar-brand" to="/"><img src="../../assets/images/logo.png"></router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse container" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
         <router-link class="nav-link active" aria-current="page" to="/">Home</router-link> 
        </li>
        <li class="nav-item">
            <router-link class="nav-link active" aria-current="page" to="/shop">Shop</router-link>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Link</a>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Dropdown
          </a>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><hr class="dropdown-divider"></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" aria-disabled="true">Disabled</a>
        </li>
      </ul>
      <form class="d-flex" role="search">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Search</button>
      </form>
    </div>
  </div>
</nav>

</div>
</template>

<script>
export default {

}
</script>
<style>
.cart-no {
    position: absolute;
    min-height: 25px;
    min-width: 25px;
    border-radius: 50%;
    font-size: 1em;
    background: blue;
    color: white;
    text-align: center;
    top: -12px;
    right: 32px;
}

</style>