import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class ReportsService {
  async createReport(reportData) {
    const response = await api.post('api/reports', reportData)
    logger.log('CREATED REPORT 📃', response.data)
  }
}

export const reportsService = new ReportsService()