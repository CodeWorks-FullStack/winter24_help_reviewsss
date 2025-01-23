<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import SideBar from './components/SideBar.vue';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <div class="container-fluid">
      <div class="row">
        <aside class="col-md-2">
          <SideBar />
        </aside>
        <section class="col-md-10">
          <router-view />
        </section>
      </div>
    </div>
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
