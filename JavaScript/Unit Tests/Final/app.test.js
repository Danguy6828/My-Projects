import { beforeEach, describe, expect, it, vi } from 'vitest';
import {employeeCounter, paySalary, takeInfo, testFICA} from './app'
import fs from 'fs'
import path from "path";
import {Window} from 'happy-dom'

const htmlDocPath = path.join(process.cwd(), 'index.html')
const htmlDocumentContent = fs.readFileSync(htmlDocPath).toString()
const window = new Window()
const document = window.document
vi.stubGlobal('document', document)

beforeEach(() => {
    document.body.innerHTML = ''
    document.write(htmlDocumentContent)
})

describe('paySalary', () => {
    it('should return the proper pay when under or equal to 40 hours', () => {
        const employeeHours = 40;
        const salary = paySalary(employeeHours)
        expect(salary).toBe(400);
    })

    it('should return the proper pay when over 40 hours', () => {
        const employeeHours = 46;
        const salary = paySalary(employeeHours)
        expect(salary).toBe(490);
    })

    it('should return 0 when no value is entered', () => {
        const employeeHours = '';
        const salary = paySalary(employeeHours)
        expect(salary).toBe(0);
    })
})

describe('takeInfo', () => {
    it('should properly add the default name to the html page', () => {
        const employeeValues = takeInfo()
        const nameBody = document.getElementById('name').innerHTML
        expect(nameBody).toBe(`Employee Name: David Nguyen`);
    })

    it('should properly add the default salary to the html page', () => {
        const employeeValues = takeInfo()
        const payBody = document.getElementById('pay').innerHTML
        expect(payBody).toBe(`Employee Gross Pay: 550`);
    })

    it('should properly add the employee name to the html page', () => {
        const name = 'Bobina'
        document.getElementById('name').value = name
        const employeeValues = takeInfo()
        const nameBody = document.getElementById('name').innerHTML
        expect(nameBody).toBe(`Employee Name: ` + name);
    })

    it('should properly add the calculated salary to the html page', () => {
        const employeeHours = 40
        document.getElementById('hours').value = employeeHours
        const salary = paySalary(employeeHours)
        const employeeValues = takeInfo()
        const payBody = document.getElementById('pay').innerHTML
        expect(payBody).toBe(`Employee Gross Pay: ` + salary);
    })

    it('should properly return a blank name to the html page', () => {
        const name = ' '
        document.getElementById('name').value = name
        const employeeValues = takeInfo()
        const nameBody = document.getElementById('name').innerHTML
        expect(nameBody).toBe(`Employee Name: ` + name);
    })

    it('should return a 0 salary when no value is entered', () => {
        const employeeHours = ' '
        document.getElementById('hours').value = employeeHours
        const salary = paySalary(employeeHours)
        const employeeValues = takeInfo()
        const payBody = document.getElementById('pay').innerHTML
        expect(payBody).toBe(`Employee Gross Pay: 0` );
    })
})

describe('employeeCounter', () => {
    it('should pass if there are 35 employee times submitted', () => {
        const employeeSubmit = 35
        const employeeCheck = employeeCounter(employeeSubmit);
        expect(employeeCheck).toBe(true);
    })

    it('should fail if there are not 35 employee times submitted', () => {
        const employeeSubmit = 34
        const employeeCheck = employeeCounter(employeeSubmit);
        expect(employeeCheck).toBe(true);
    })

    it('should return false if there are not than 35 employee times submitted', () => {
        const employeeSubmit = 34
        const employeeCheck = employeeCounter(employeeSubmit);
        expect(employeeCheck).toBe(false);
    })
})

describe('testFICA', () => {
    it('should return the correct tax amount of 19268.98 after all 35 times are submitted', () => {
        const employeeSubmit = 35
        const expectedTax = 19268.98
        const taxCheck = testFICA(employeeSubmit);
        expect(taxCheck).toBe(expectedTax)
    })

    it('should fail if not all 35 times are submitted', () => {
        const employeeSubmit = 34
        const expectedTax = 19268.98
        const taxCheck = testFICA(employeeSubmit);
        expect(taxCheck).toBe(expectedTax)
    })
})