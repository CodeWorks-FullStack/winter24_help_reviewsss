<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({
  restaurant: { type: Restaurant, required: true }
})
</script>


<template>
  <div class="restaurant-card m-2">
    <img :src="restaurant.imgUrl" :alt="'A picture of ' + restaurant.name">
    <div class="p-3">
      <b class="text-success">{{ restaurant.name }}</b>
      <p>{{ restaurant.description }}</p>
      <div class="d-flex align-items-center">
        <i class="mdi mdi-account-multiple-outline text-success fs-2"></i>
        <span><b>{{ restaurant.visits }}</b> recent visits</span>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
img {
  width: 100%;
  height: 45dvh;
  object-fit: cover;
  object-position: center;
}

.restaurant-card {
  box-shadow: 0 3px 10px rgb(81, 81, 81);
}
</style>