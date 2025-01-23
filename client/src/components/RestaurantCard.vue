<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({
  restaurant: { type: Restaurant, required: true }
})
</script>


<template>
  <div>
    <img :src="restaurant.imgUrl" :alt="'A picture of ' + restaurant.name">
  </div>
</template>


<style lang="scss" scoped>
img {
  width: 100%;
  height: 45dvh;
  object-fit: cover;
  object-position: center;
}
</style>