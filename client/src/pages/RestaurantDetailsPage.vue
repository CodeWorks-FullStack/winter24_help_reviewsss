<script setup>
import { restaurantsService } from '@/services/RestaurantsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

onMounted(() => {
  getRestaurantById()
})

async function getRestaurantById() {
  try {
    const restaurantId = route.params.restaurantId
    await restaurantsService.getRestaurantById(restaurantId)
  } catch (error) {
    Pop.meow(error)
    logger.error('[GETTING RESTAURANT BY ID]', error.message)
  }
}
</script>


<template>
  <h1>Restaurant page!</h1>
</template>


<style lang="scss" scoped></style>