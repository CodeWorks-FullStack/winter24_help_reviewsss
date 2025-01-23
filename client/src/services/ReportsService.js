import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class ReportsService {
  async getReportsByRestaurantId(restaurantId) {
    const response = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('GOT REPORTS 📃📃📃📃', response.data)
  }
  async createReport(reportData) {
    const response = await api.post('api/reports', reportData)
    logger.log('CREATED REPORT 📃', response.data)
    // TODO update appstate
  }
}

export const reportsService = new ReportsService()