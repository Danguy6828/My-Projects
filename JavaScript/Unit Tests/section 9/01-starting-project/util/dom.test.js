import { afterEach, beforeEach, expect, it, vi } from "vitest";
import { showError } from "./dom";
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
//changed some of the variable names in each test
it('should add an error paragraph to the id=errors element', () => {
    showError('duck error')
    const errorElements = document.getElementById('errors')
    const errorBody = errorElements.firstElementChild
    expect(errorBody).not.toBeNull()
})

//changed the test description
it('should not return an error if no error message is provided', () => {
    const errorElements = document.getElementById('errors')
    const errorBody = errorElements.firstElementChild
    expect(errorBody).toBeNull()
})

// changed the error message
it('should output the provided message in the error paragraph', () => {
    const testMessage = '1fgX-$32'
    showError(testMessage)
    const errorElements = document.getElementById('errors')
    const errorBody = errorElements.firstElementChild
    expect(errorBody.textContent).toBe(testMessage)
})
