<template>
  <div class="register">
    <div class="warp-register flex-row-between">
      <div class="form-register flex-column-between">
        <img src="../assets/images/logo.svg" alt="" class="logo" />
        <div class="title">Đăng ký</div>
        <div v-if="!validRegister" class="validate-register">
          {{ validMsg }}
        </div>
        <div class="input-register">
          <div class="label">Họ và tên</div>
          <div class="content">
            <base-input v-model="user.FullName"></base-input>
          </div>
        </div>
        <div class="input-register">
          <div class="label">Tên đăng nhập</div>
          <div class="content">
            <base-input v-model="user.UserName"></base-input>
          </div>
        </div>
        <div class="input-register">
          <div class="label">Mật khẩu</div>
          <div class="content">
            <base-input v-model="user.Password" type="password"></base-input>
          </div>
        </div>
        <div class="register-btn">
          <base-button
            textBtn="Đăng ký"
            classButton="btn-primary"
            @click="register"
          ></base-button>
        </div>
        <div class="has-account flex">
          Bạn dã có tài khoản?
          <p @click="login">Đăng nhập</p>
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
  name: "TheRegister",
  components: {},
  data() {
    return {
      module: "module_user",
      validRegister: true,
      validMsg: "",
      user: {
        FullName: null,
        UserName: null,
        Password: null,
      },
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
      this.$router.push("/login");
    },

    register() {
      const me = this;
      let valid = this.validateReister();
      if (valid) {
        this.setLoading(true);
        userAPI
          .register(this.user)
          .then((res) => {
            if (res && res.data && res.data.Success) {
              Vue.$toast.success("Đăng ký tài khoản thành công.");
              setTimeout(() => {
                me.$router.push("/login");
              }, 3000);
            } else {
              Vue.$toast.error(res.data.UserMsg);
            }
          })
          .catch((err) => {
            Vue.$toast.error(
              "Đăng ký tài khoản không thành công. Vui lòng thử lại sau!"
            );
          })
          .finally(() => {
            this.setLoading(false);
          });
      }
    },

    validateReister() {
      if (!this.user.UserName || !this.user.Password || !this.user.FullName) {
        this.validMsg =
          "Họ và tên, Tên đăng nhập và Mật khẩu không được để trống";
        this.validRegister = false;
        return false;
      } else {
        this.validRegister = true;
        return true;
      }
    },
  },
};
</script>