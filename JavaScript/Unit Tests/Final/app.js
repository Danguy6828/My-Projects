export function paySalary(employeeHours) {
    if (employeeHours <= 40) {
      var regtime = 10.00 * employeeHours;
      var overtime = 0.00;
      var salary = regtime;
    } else if (employeeHours > 40) {
       var regtime = (10.00 * 40);
       var overtime = ((10.00 * 1.5) * (employeeHours - 40));
       var salary = (regtime + overtime);
    }
    return salary
}

export function takeInfo() {
    var employeeName = document.getElementById("name").value;
    var employeeHours = document.getElementById("hours").value;
    const salary = paySalary(employeeHours)
    document.getElementById("name").innerHTML = "Employee Name: " + employeeName;
    document.getElementById("pay").innerHTML = "Employee Gross Pay: " + salary;
}

export function employeeCounter(employeeTimes) {
    if (employeeTimes == 35) {
      return true
    } else {
      return false
    }
}

export function testFICA(employeeTimes) {
    var taxValue = 550.5422
    var taxCalc = taxValue * employeeTimes
    return Number(taxCalc.toFixed(2))
}