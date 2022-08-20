<template>
  <v-card>
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
    <v-container>
      <v-text-field hide-details label="Search" class="rounded-xl" append-inner-icon="mdi-magnify"/>
    </v-container>
  </v-card>

  <v-card>
    <v-list lines="two" style="background-color:rgb(22,31,44, 0)">
      <router-link  to="/" class="reset-a">
        <v-list-item v-if="userHasClan"  style="padding-bottom: 0;">
          <template v-slot:title>
            <span>GRS </span> <span class="winter-sky">| Generic Race Server</span>
          </template>
          <template v-slot:prepend>
            <v-avatar>
              <v-img src="/src/images/GRSwhiteV2.png" class="mx-auto"></v-img>
            </v-avatar>
          </template>
          <template v-slot:append>
            <v-avatar>
              14&nbsp;
              <v-icon class="azure">mdi-account-group</v-icon>
            </v-avatar>
          </template>

          <template v-slot:subtitle>
            <span>Racing B)</span>
          </template>
        </v-list-item>
        <v-list-item v-else  style="padding-bottom: 0;">
          <v-btn class="btn-submit w-100">CREATE NEW CLAN</v-btn>
        </v-list-item>
      </router-link>
      
      <v-divider color="#FF006E"/>
      
      <router-link to="/" class="reset-a">
        <v-list-item style="padding-bottom: 0;"
        >
          <template v-slot:title>
            <span>GRS </span> <span class="winter-sky">| Generic Race Server</span>
          </template>
          <template v-slot:prepend>
            <v-avatar>
              <v-img src="/src/images/GRSwhiteV2.png" class="mx-auto"></v-img>
            </v-avatar>
          </template>
          <template v-slot:append>
            <v-avatar>
              14&nbsp;
              <v-icon class="azure">mdi-account-group</v-icon>
            </v-avatar>
          </template>

          <template v-slot:subtitle>
            <span>Racing B)</span>
          </template>
        </v-list-item>
      </router-link>

      <router-link to="/" class="reset-a">
        <v-list-item style="padding-bottom: 0;"
        >
          <template v-slot:title>
            <span>HP </span> <span style="color: orange">| Hot pursuit</span>
          </template>
          <template v-slot:prepend>
            <v-avatar>
              <v-img src="/src/images/GRSwhiteV2.png" class="mx-auto"></v-img>
            </v-avatar>
          </template>
          <template v-slot:append>
            <v-avatar>
              5&nbsp;
              <v-icon class="azure">mdi-account-group</v-icon>
            </v-avatar>
          </template>

          <template v-slot:subtitle>
            <span>Slooow</span>
          </template>
        </v-list-item>
      </router-link>
    </v-list>
  </v-card>
</template>

<script setup lang="ts">
import Breadcrumbs from "../components/breadcrumbs.vue";
import {ref} from "vue";

const breadCrumbsItems = [
  {
    text: 'Home',
    disabled: false,
    href: '/',
  },
  {
    text: 'Clans',
    disabled: true,
    href: 'clans',
    color: "#FF006E",
  },
];

const userHasClan = ref(false);
</script>

<style scoped>
.btn-submit {
  color: #fff;
  background-color: #242433;
  border: 1px solid #5BCE00;
}

.btn-submit:hover {
  background-color: #5BCE00;
  color: #fff;
}

.btn-blue {
  color: #fff;
  background-color: #242433;
  border: 1px solid #3A86FF;
}

.btn-blue:hover {
  background-color: #3A86FF;
  color: #fff;
}

.btn-orange {
  color: #fff;
  background-color: #242433;
  border: 1px solid #FB5607;
}

.btn-orange:hover {
  background-color: #FB5607;
  color: #fff;
}

</style>