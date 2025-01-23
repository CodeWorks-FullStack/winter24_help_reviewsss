<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({
  restaurant: { type: Restaurant, required: true }
})
</script>


<template>
  <RouterLink :to="{ name: 'RestaurantDetails', params: { restaurantId: restaurant.id } }"
    :title="`Go to ${restaurant.name}'s page`">
    <div class="restaurant-card m-2">
      <img :src="restaurant.imgUrl" :alt="'A picture of ' + restaurant.name"
        :class="{ 'gray-out': restaurant.isShutdown }">
      <div class="p-3">
        <b :class="restaurant.isShutdown ? 'text-danger' : 'text-success'">{{ restaurant.name }}</b>
        <p>{{ restaurant.description }}</p>
        <div class="d-flex justify-content-between">
          <div class="d-flex align-items-center">
            <i class="mdi mdi-account-multiple-outline fs-2"
              :class="restaurant.isShutdown ? 'text-danger' : 'text-success'"></i>
            <span><b>{{ restaurant.visits }}</b> recent visits</span>
          </div>
          <div class="d-flex align-items-center">
            <i class="mdi mdi-file-document fs-2" :class="restaurant.isShutdown ? 'text-danger' : 'text-success'"></i>
            <span><b>{{ restaurant.reportCount }}</b> reports</span>
          </div>
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