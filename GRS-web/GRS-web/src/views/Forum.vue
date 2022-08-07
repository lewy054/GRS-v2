<template>
  <v-card>
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
  </v-card>
  <h1>Forum</h1>
</template>

<script setup lang="ts">
import Breadcrumbs from "../components/breadcrumbs.vue";

const breadCrumbsItems = [
  {
    text: 'Home',
    disabled: false,
    href: '/',
  },
  {
    text: 'Forum',
    disabled: true,
    href: 'forum',
    color: "#FF006E",},
];
</script>

<style scoped>

</style>