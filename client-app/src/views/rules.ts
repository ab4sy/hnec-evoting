import { FormRules } from "naive-ui";

const phone_validator = (rule: any, value: any, callback: any) => {
  if (!value) {
    return callback();
  } else {
    if (!/^[0-9+]+$/.test(value)) {
      return callback(new Error("Phone number must be entered correctly"));
    } else if (value.length != 10) {
      callback(new Error("Length of phone number must be 10"));
    } else {
      let operatorCodesWithZero = ["092", "094", "091", "093", "095", "096"];
      let check = 0;

      switch (value.length) {
        case 10:
          check = operatorCodesWithZero.findIndex((x) => x == value.substring(0, 3));
          break;
        default:
          break;
      }
      if (check == -1) {
        callback(new Error("Must enter the Libyan phone number"));
      } else {
        return callback();
      }
    }
  }
};


export const arabic_with_numbers_validator = (rule: any, value: any, callback: any) => {
  if (!value) {
    return callback();
  }
  var isValid = /^(?!\s)[\u0621-\u064A\u0660-\u0669\0-9 ]+$/.test(String(value));
  if (!isValid) {
    callback(new Error(`Address must be in Arabic letters and numbers`))
  } else {
    callback()
  }
}


 const email_validator = (rule: any, value: any, callback: any) => {
  if (!value) {
    return callback();
  }
  var isValid = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(String(value));
  if (!isValid) {
    callback(new Error("Must enter a valid email address"))
  } else {
    callback()
  }
}


export const checkout_rules: FormRules = {
  full_name: [
    {
      required: true,
      message: "Please input your name",
      trigger: "blur",
    },
  ],
  otp: [
    {
      required: true,
      message: "Please input otp",
      trigger: "blur",
    },
  ],

  city_id: [
    {
      type: "number",

      required: true,
      message: "Please selecte city",
      trigger: "blur",
    },
  ],


  // district_id: [
  //   {
  //     required: true,
  //     message: "Please selecte district",
  //     trigger: "blur",
  //   },
  // ],
  phone_number: [
    {
      required: true,
      message: "Please input your phone",
      trigger: ["input", "blur"],
    },
    {
      validator: phone_validator,
      trigger: ["input", "blur"],
    },
  ],
  address: [
    {
      required: true,
      message: "Please input your address",
      trigger: ["input", "blur"],
    },
    {
      validator: arabic_with_numbers_validator,
      trigger: ["input", "blur"],
    },
  ],

  email: [

    {
      validator: email_validator,
      trigger: ["input", "blur"],
    },
  ],
};


