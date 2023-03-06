config input string {
  default = "hello"
}

resource password "random:index/randomPassword:RandomPassword" {
  length = 16
  special = true
  overrideSpecial = input
}

output result {
  value = password.result
}

output createdResource {
  value = password
}