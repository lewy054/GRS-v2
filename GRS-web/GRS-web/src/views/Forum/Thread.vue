<template>
  <v-card color="rgb(22,31,44, 0.7)">
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
    <div>
      <v-card color="rgb(22,31,44, 0)">
        <v-list-item style="padding-bottom: 0;"
                     :title="props.title"
        >
          <template v-slot:prepend>
            <v-avatar class="mb-5">
              <v-img src="../../src/images/grs-logo.svg"></v-img>
            </v-avatar>
          </template>

          <template v-slot:subtitle>
            <span>by <span class="font-weight-bold">User</span> 5 Minutes Ago</span>
          </template>
        </v-list-item>
      </v-card>
      <v-container>
      <span>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
      </span>
        <v-row class="mt-3 ml-1">
          <v-icon color="green">mdi-plus-circle</v-icon>
          <v-icon color="red">mdi-minus-circle</v-icon>
          <div class="ml-3">
            <span>14</span>
            <v-icon color="green">mdi-plus</v-icon>
          </div>
        </v-row>
      </v-container>
    </div>
    <v-divider color="#FF006E"/>

    <div>
      <v-card color="rgb(22,31,44, 0)">
        <v-list-item style="padding-bottom: 0;"
                     title="User1"
        >
          <template v-slot:prepend>
            <v-avatar class="mb-5">
              <v-img src="../../src/images/grs-logo.svg"></v-img>
            </v-avatar>
          </template>

          <template v-slot:subtitle>
            <span> 3 Minutes Ago</span>
          </template>
        </v-list-item>
      </v-card>
      <v-container>
      <span>
        Lorem not ipsum
      </span>
        <v-row class="mt-3 ml-1">
          <v-icon color="green">mdi-plus-circle</v-icon>
          <v-icon color="red">mdi-minus-circle</v-icon>
          <div class="ml-3">
            <span>5</span>
            <v-icon color="red">mdi-minus</v-icon>
          </div>
        </v-row>
      </v-container>
    </div>
  </v-card>

</template>

<script setup lang="ts">
import {defineProps} from "vue/dist/vue.js";
import {useRouter} from "vue-router";
import Breadcrumbs from "../../components/breadcrumbs.vue";

const props = defineProps({
  threadName: String,
  title: String,
  link: String,
});

const router = useRouter();

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
    text: props.title,
    disabled: true,
    href: props.title,
    color: "#FF006E",
  },
];
</script>

<style scoped>

</style>