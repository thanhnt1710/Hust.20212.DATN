<template>
  <div id="app">
    <div class="main-contain">
      <the-header></the-header>
      <the-main></the-main>
      <the-footer></the-footer>
    </div>
  </div>
</template>

<style scoped>
@import '@/scss/base/main.scss';
</style>

<script>
import TheHeader from '@/layouts/TheHeader.vue'
import TheMain from '@/layouts/TheMain.vue'
import TheFooter from '@/layouts/TheFooter.vue'
export default {
    name: 'App',
    components: {
        TheHeader,
        TheMain,
        TheFooter
    },
    props: {
        
    }
}
</script>
