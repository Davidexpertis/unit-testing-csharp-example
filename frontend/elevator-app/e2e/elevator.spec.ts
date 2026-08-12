import { test, expect } from '@playwright/test';

test.describe('Elevator app', () => {
  test('loads the elevator page and shows the status widget', async ({ page }) => {
    await page.goto('/');

    await expect(page.locator('h1')).toHaveText('elevator-app');
    await expect(page.getByRole('heading', { name: 'Elevator Status' })).toBeVisible();

    // Depending on whether the backend API is running, either the status list
    // or a connection error message should be shown.
    const status = page.getByTestId('elevator-status');
    const error = page.getByTestId('error-message');
    await expect(status.or(error)).toBeVisible();
  });

  test('allows entering employee data', async ({ page }) => {
    await page.goto('/');

    await page.getByTestId('employee-name').fill('Test Employee');
    await page.getByTestId('employee-weight').fill('80');
    await page.getByTestId('employee-executive').check();

    await expect(page.getByTestId('employee-name')).toHaveValue('Test Employee');
    await expect(page.getByTestId('employee-weight')).toHaveValue('80');
    await expect(page.getByTestId('employee-executive')).toBeChecked();
  });
});
