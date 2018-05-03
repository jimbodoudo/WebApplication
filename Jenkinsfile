pipeline {
  agent {
    docker {
      image 'jenkins'
    }

  }
  stages {
    stage('Stage1') {
      steps {
        sleep 10
        mail(subject: 'allo', body: 'hello', from: 'no@familiprix.com', to: 'jbourque@familiprix.com')
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
        stage('') {
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
  }
  environment {
    test = 'asdfdsf'
  }
}