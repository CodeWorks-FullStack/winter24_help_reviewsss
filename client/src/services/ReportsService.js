import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Report } from "@/models/Report.js"

class ReportsService {
  async getReportsByRestaurantId(restaurantId) {
    const response = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('GOT REPORTS 📃📃📃📃', response.data)
    AppState.reports = response.data.map(pojo => new Report(pojo))
  }
  async createReport(reportData) {
    const response = await api.post('api/reports', reportData)
    logger.log('CREATED REPORT 📃', response.data)
    AppState.reports.unshift(new Report(response.data))
  }
}

export const reportsService = new ReportsService()