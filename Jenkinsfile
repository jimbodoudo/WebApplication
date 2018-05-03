pipeline {
  agent none
  stages {
    stage('Stage1') {
      steps {
        sleep 10
        sleep 5
      }
    }
    stage('Stage2') {
      parallel {
        stage('Stage2') {
          steps {
            sleep 2
          }
        }
        stage('error') {
          steps {
            sleep 3
          }
        }
      }
    }
    stage('final stage') {
      steps {
        echo 'it\'s finished!'
      }
    }
    stage('') {
      steps {
        input(message: 'Is it ok for you guy?', id: 'no', ok: 'yes')
      }
    }
  }
  environment {
    test = 'asdfdsf'
  }
}