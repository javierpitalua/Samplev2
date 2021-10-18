<template>
  <input type="text" placeholder="Search by login" v-model="searchPattern" />
  <div class="user-list">
    <div v-for="item in data" v-bind:key="item.id">
      <div>
        Login: <span class="bold"> {{ item.login }} </span>
        <span> Roles:</span>
        <span
          class="bold"
          v-for="role in item.roles"
          v-bind:key="role.id">
          {{ role.name }}&nbsp;
        </span>
        <span>, Office:</span><span class="bold">{{ item.office.address }}</span>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, watch } from "vue";
import type from "@/core/Type";
import userService, { User } from "@/services/UserService";

export default {
  props: {
    users: type<User[]>(),
  },
  setup(props) {
    let searchPattern = ref("");
    let data = ref([] as User[]);

    data.value = props.users;

    watch(searchPattern, (newValue) => {
      if(newValue && newValue.length > 0) {
          data.value = props.users.filter((element) =>
              element.login.toLowerCase().includes(newValue.toLowerCase()));
      } else {
        data.value = props.users;
      }      
    });

    return {
      searchPattern,
      data,
    };
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.bold {
  font-weight: bold;
}
.user-list {
  text-align: left;
}
</style>