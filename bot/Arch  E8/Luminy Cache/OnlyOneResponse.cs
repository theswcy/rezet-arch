// Módulo para previnir spam e falha em funções.

// Rate limit:
// - A cada 1 comando executado = intervalo de tempo de 2 segundos.
// - Cada rate limit será armazenado no cache: { "user_id": 1 }    1 = true.

// Evitar múltiplas respostas:
// - Verificar se a última mensagem pertence a Rezet.
// - Caso seja da Rezet, interromper processo, caso contrário, prosseguir.