from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.action_chains import ActionChains
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.chrome.options import Options
import time

# Setup Chrome options
options = Options()
options.add_argument("--start-maximized")
options.add_argument("--disable-popup-blocking")

# Initialize WebDriver
driver = webdriver.Chrome(options=options)
wait = WebDriverWait(driver, 10)

try:
    # Navigate to a test page
    driver.get("https://the-internet.herokuapp.com/")

    # Click a link
    driver.find_element(By.LINK_TEXT, "Form Authentication").click()

    # Fill out login form
    driver.find_element(By.ID, "username").send_keys("tomsmith")
    driver.find_element(By.ID, "password").send_keys("SuperSecretPassword!")
    driver.find_element(By.CSS_SELECTOR, "button[type='submit']").click()

    # Wait for success message
    wait.until(EC.visibility_of_element_located((By.CLASS_NAME, "flash.success")))

    # Take a screenshot
    driver.save_screenshot("login_success.png")

    # Navigate back and interact with checkboxes
    driver.back()
    driver.find_element(By.LINK_TEXT, "Checkboxes").click()
    checkboxes = driver.find_elements(By.CSS_SELECTOR, "input[type='checkbox']")
    for box in checkboxes:
        if not box.is_selected():
            box.click()

    # Handle JavaScript alert
    driver.get("https://the-internet.herokuapp.com/javascript_alerts")
    driver.find_element(By.XPATH, "//button[text()='Click for JS Alert']").click()
    alert = driver.switch_to.alert
    alert.accept()

    # Handle confirm alert
    driver.find_element(By.XPATH, "//button[text()='Click for JS Confirm']").click()
    driver.switch_to.alert.dismiss()

    # Handle prompt alert
    driver.find_element(By.XPATH, "//button[text()='Click for JS Prompt']").click()
    prompt = driver.switch_to.alert
    prompt.send_keys("Selenium Test")
    prompt.accept()

    # Switch to iframe
    driver.get("https://the-internet.herokuapp.com/iframe")
    iframe = driver.find_element(By.ID, "mce_0_ifr")
    driver.switch_to.frame(iframe)
    editor = driver.find_element(By.ID, "tinymce")
    editor.clear()
    editor.send_keys("Hello from Selenium!")
    driver.switch_to.default_content()

    # Open new window and switch
    driver.execute_script("window.open('https://example.com');")
    driver.switch_to.window(driver.window_handles[1])
    print("New window title:", driver.title)
    driver.close()
    driver.switch_to.window(driver.window_handles[0])

    # Perform mouse hover
    driver.get("https://the-internet.herokuapp.com/hovers")
    avatar = driver.find_element(By.CLASS_NAME, "figure")
    ActionChains(driver).move_to_element(avatar).perform()

    # Execute JavaScript
    driver.execute_script("alert('This is a JS alert from Selenium!');")
    driver.switch_to.alert.accept()

    # Manage cookies
    driver.get("https://example.com")
    driver.add_cookie({"name": "test_cookie", "value": "cookie_value"})
    print("Cookies:", driver.get_cookies())
    driver.delete_all_cookies()

    # Log browser console (if supported)
    logs = driver.get_log("browser")
    for entry in logs:
        print(entry)

finally:
    time.sleep(3)
    driver.quit()
