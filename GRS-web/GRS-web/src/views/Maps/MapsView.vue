<template>
  <v-card color="rgb(22,31,44, 0.7)">
  <v-container>
    <v-text-field hide-details label="Search" class="rounded-xl" append-inner-icon="mdi-magnify"/>
  </v-container>
  <v-container>
    <v-list>
      <v-list-item title="Test Map 1" class="mt-2 reset-a" 
                   subtitle="Author: User">
        <template v-slot:prepend>
          <v-avatar>
            <v-icon size="x-large" color="blue">mdi-chevron-right</v-icon>
          </v-avatar>
        </template>
        <template v-slot:append>
          <v-avatar>
            <v-icon size="x-large" color="red">mdi-close</v-icon>
          </v-avatar>
        </template>
      </v-list-item>
      <v-list-item title="Test Map 2" class="mt-2 reset-a"
                   subtitle="Author: User2">
        <template v-slot:prepend>
          <v-avatar>
            <v-icon size="x-large" color="blue">mdi-chevron-right</v-icon>
          </v-avatar>
        </template>
        <template v-slot:append>
          <v-avatar>
            <v-icon size="x-large" color="green">mdi-check</v-icon>
          </v-avatar>
        </template>
      </v-list-item>
    </v-list>
  </v-container>
  </v-card>
</template>

<script setup lang="ts">

</script>

<style scoped>

</style>