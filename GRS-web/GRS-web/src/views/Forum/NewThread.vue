<template>
  <v-card color="rgb(22,31,44, 0.7)">
    <v-container>
      <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
      <v-text-field label="Title" class="rounded-xl"></v-text-field>
      <v-textarea label="Content" rows="3" class="rounded-xl"></v-textarea>
      <div class="float-right mb-3">
        <v-btn class="btn-submit rounded-xl" append-icon="mdi-feather">POST THREAD</v-btn>
      </div>
    </v-container>
  </v-card>
</template>

<script setup lang="ts">

import Breadcrumbs from "../../components/breadcrumbs.vue";
import {defineProps} from "vue";

const props = defineProps({
  threadName: String,
  link: String,
});
console.log(props.threadName)
console.log(props.link)


const breadCrumbsItems = [
  {
    text: 'Home',
    disabled: false,
    href: '/',
  },
  {
    text: 'Forum',
    disabled: false,
    href: '/forum',
  },
  {
    text: props.threadName,
    disabled: false,
    href: '/forum/' + props.link,
  },
  {
    text: 'New Thread',
    disabled: true,
    href: '/new-thread',
    color: "#FF006E",
  },
];
</script>

<style scoped>
.btn-submit {
  color: #fff;
  background-color: #242433;
  border: 1px solid #5BCE00;
}
</style>