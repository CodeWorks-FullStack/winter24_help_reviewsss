<script setup>
import { AppState } from '@/AppState.js';
import { restaurantsService } from '@/services/RestaurantsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const restaurant = computed(() => AppState.activeRestaurant)
const account = computed(() => AppState.account)

const route = useRoute() // information about the route
const router = useRouter() // tool to change the route

watch(route, () => {
  getRestaurantById()
}, { immediate: true })

async function getRestaurantById() {
  try {
    const restaurantId = route.params.restaurantId
    await restaurantsService.getRestaurantById(restaurantId)
  } catch (error) {
    Pop.meow(error)
    logger.error('[GETTING RESTAURANT BY ID]', error.message)
    router.push({ name: 'Home' })
  }
}

async function deleteRestaurant() {
  try {
    const confirmed = await Pop.confirm(`Are you sure you want to delete ${restaurant.value.name}?`)
    if (!confirmed) return
    const restaurantId = route.params.restaurantId
    await restaurantsService.deleteRestaurant(restaurantId)
    router.push({ name: 'Home' })
  } catch (error) {
    Pop.meow(error)
    logger.error('[DELETING RESTAURANT BY ID]', error.message)
  }
}

async function toggleShutdownStatus() {
  try {
    const updateData = { isShutdown: !restaurant.value.isShutdown }
    const restaurantId = route.params.restaurantId
    await restaurantsService.updateRestaurant(restaurantId, updateData)
  } catch (error) {
    Pop.meow(error)
    logger.error('[UPDATING RESTAURANT BY ID]', error.message)
  }
}
</script>


<template>
  <div class="p-3">
    <div v-if="restaurant" class="container-fluid">
      <section class="row">
        <div class="col-12">
          <div class="d-md-flex justify-content-between">
            <h1 class="text-success"><b>{{ restaurant.name }}</b></h1>
            <span v-if="restaurant.isShutdown" class="fs-1 bg-danger text-light px-3">
              <i class="mdi mdi-close-circle"></i>
              CURRENTLY SHUTDOWN
            </span>
          </div>
          <div class="restaurant-card">
            <img :src="restaurant.imgUrl" :alt="'A picture of ' + restaurant.name" class="restaurant-img"
              :class="{ 'gray-out': restaurant.isShutdown }">
            <div class="p-3">
              <p>Owned and operated by {{ restaurant.owner.name }}</p>
              <p class="mb-5">{{ restaurant.description }}</p>
              <div class="d-md-flex justify-content-between align-items-center">
                <div class="d-flex gap-5">
                  <div class="d-flex align-items-center">
                    <i class="mdi mdi-account-multiple-outline fs-1 text-success"></i>
                    <span><b>{{ restaurant.visits }}</b> recent visits</span>
                  </div>
                  <div class="d-flex align-items-center">
                    <i class="mdi mdi-file-document fs-1 text-success"></i>
                    <span><b>0</b> reports</span>
                  </div>
                </div>
                <div v-if="restaurant.creatorId == account.id" class="d-flex gap-5">
                  <button @click="toggleShutdownStatus()" class="btn btn-success fs-5">
                    <i class="mdi mdi-door-open"></i>
                    Re-Open
                  </button>
                  <button @click="deleteRestaurant()" class="btn btn-danger fs-5">
                    <i class="mdi mdi-delete-forever"></i>
                    Delete
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
    <div v-else>
      <h1 class="text-center">Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.restaurant-img {
  width: 100%;
  height: 40dvh;
  object-fit: cover;
}
</style>