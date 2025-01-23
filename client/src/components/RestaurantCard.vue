<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({
  restaurant: { type: Restaurant, required: true }
})
</script>


<template>
  <RouterLink :to="{ name: 'RestaurantDetails', params: { restaurantId: restaurant.id } }">
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
  </RouterLink>
</template>


<style lang="scss" scoped>
img {
  width: 100%;
  height: 45dvh;
  object-fit: cover;
  object-position: center;
}
</style>