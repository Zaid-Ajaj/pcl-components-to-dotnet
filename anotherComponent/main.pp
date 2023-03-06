resource password "random:index/randomPassword:RandomPassword" {
  length = 16
  special = true
}

output value {
  value = password.result
}