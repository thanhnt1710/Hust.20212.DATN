<template>
  <div class="login">
    <div class="warp-login flex-row-between">
      <div class="form-login flex-column-between">
        <img src="../assets/images/logo.svg" alt="" class="logo" />
        <div class="title">Đăng nhập</div>
        <div v-if="!validLogin" class="validate-login">
          {{ validMsg }}
        </div>
        <div class="input-login">
          <div class="label">Tên đăng nhập</div>
          <div class="content">
            <base-input v-model="userName"></base-input>
          </div>
        </div>
        <div class="input-login">
          <div class="label">Mật khẩu</div>
          <div class="content">
            <base-input v-model="password" type="password"></base-input>
          </div>
        </div>
        <div class="login-btn">
          <base-button
            textBtn="Đăng nhập"
            classButton="btn-primary"
            @click="login"
          ></base-button>
        </div>
        <div class="no-account flex">
          Bạn chưa có tài khoản?
          <p @click="register">Đăng ký</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/login_register.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations } from "vuex";
import userAPI from "@/apis/views/userAPI.js";

export default {
  name: "TheLogin",
  components: {},
  data() {
    return {
      module: "module_user",
      userName: null,
      password: null,
      validLogin: true,
      validMsg: "",
    };
  },
  computed: {
    ...mapState({
      loading: (state) => state.loading,
    }),
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
    }),

    login() {
      let valid = this.validateLogin();
      if (valid) {
        let payload = {
          UserName: this.userName,
          Password: this.password,
        };
        this.setLoading(true);
        userAPI
          .login(payload)
          .then((res) => {
            if (res && res.data) {
              let result = res.data;
              if (result.Success) {
                localStorage.setItem("token", result.Data.Token);
                delete result.Data.Token;
                localStorage.setItem("context", JSON.stringify(result.Data));
                this.$router.push("/");
              } else {
                this.validMsg = result.UserMsg;
                this.validLogin = false;
              }
            }
          })
          .catch((err) => {
            Vue.$toast.error("Có lỗi xảy ra vui lòng thử lại sau!");
          })
          .finally(() => {
            this.setLoading(false);
          });
      }
    },
    validateLogin() {
      if (!this.userName || !this.password) {
        this.validMsg = "Tên đăng nhập và mật khẩu không được để trống";
        this.validLogin = false;
        return false;
      } else {
        this.validRegister = false;
        return true;
      }
    },
    register() {
      this.$router.push("/register");
    },
  },
};
</script>